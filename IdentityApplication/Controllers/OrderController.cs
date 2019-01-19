using gellmvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static gellmvc.Domain.Entities.Cart;
using Microsoft.AspNet.Identity;
using gellmvc.Domain.Abstract;
using gellmvc.Models;
using gellmvc.Helpers;

namespace gellmvc.Controllers
{
  [Authorize]
  public class OrderController : Controller
  {
    protected IUserAddressRepository m_userAddressRepo;
    protected IOrderRepository m_orderRepo;

    private bool m_gotAddressesInDatabase = false;
    private IEnumerable<Domain.Entities.UserAddress> m_addressesInDatabase;
    private string m_userId;

    public OrderController(IUserAddressRepository userAddyRepo, IOrderRepository orderRepo){
      m_userAddressRepo = userAddyRepo;
      m_orderRepo = orderRepo;
    }
    
    public ActionResult Index(){
      IEnumerable<Order> orders = m_orderRepo.GetOrdersByCustomerId(User.Identity.GetUserId());
      OrderIndexViewModel model = new OrderIndexViewModel{
        Orders = orders.ToList()
      };
      return View(model);
    }

    public ActionResult Show(int? orderId)
    {
      if (orderId == null){ return RedirectToAction("Index");}
      Order order = m_orderRepo.GetOrderById((int)orderId, new Domain.Concrete.EFProductRepository());
      OrderViewModel model = new OrderViewModel{
        Order = order
      };
      return View(model);
    }

    public ActionResult Create(){
      //TempData.Keep();
      return Redirect("/Checkout/Index");
    }

    [HttpPost]
    public ActionResult Create(Cart cart, CartIndexViewModel model)
    {
      Debug.WriteLine("Try to create an order...");

      m_userId = User.Identity.GetUserId();

      if (String.IsNullOrEmpty(m_userId))
      {
        TempData["flashDanger"] = "Please login before you can place this order.";
        TempData["CartIndexViewModel"] = model;
        return RedirectToAction("Login", "Account", new { returnURL = "/Checkout/Index" });
      }

      // Copy the POS details from shipping to billing, if the user has checked the checkbox.
      if (model.AddressFieldsPOS.sameForBilling == true) { model.AddressFieldsPOS.BillingAddressPOS = model.AddressFieldsPOS.ShippingAddressPOS; }

      if (!model.ValidAddress())
      {
        Debug.WriteLine("User has got no addresses");
        TempData["flashDanger"] = "Please provide your Shipping and Billing address information.";
        return RedirectToAction("Index", "Checkout");
      }
      else
      {
        Debug.WriteLine("Address info is available...");

        if (PlaceOrder(cart, model))
        {
          Debug.WriteLine("Order created successfully.");
          TempData["flashSuccess"] = "Your order was created successfully.";
        }
        else
        {
          Debug.WriteLine("Could not create order.");
          TempData["flashDanger"] = "Could not create order.";
        }
      }
      return RedirectToAction("Index", "Order");
    }

    private bool PlaceOrder(Cart cart, CartIndexViewModel model)
    {
      Models.UserAddress shipvm = model.ShippingAddress();
      Models.UserAddress billvm = model.BillingAddress();
      shipvm.UserId = m_userId;
      billvm.UserId = m_userId;

      // Try to look up from database.
      Domain.Entities.UserAddress ship = m_userAddressRepo.GetAddressById(shipvm.Id as int?);
      Domain.Entities.UserAddress bill = m_userAddressRepo.GetAddressById(billvm.Id as int?);

      // Not in database.
      if (ship == null) { ship = ModelHelpers.DomainUserAddress(shipvm); }
      if (bill == null) { bill = ModelHelpers.DomainUserAddress(billvm); }

      if (model.addressMode == CartIndexViewModel.AddressMode.PointOfSale)
      {
        // Check if we already have a matching address in the database that we can use.
        Domain.Entities.UserAddress shipMatch = m_userAddressRepo.UserAddresses.Where(a => a.Line1.ToLower().Equals(ship.Line1.ToLower())).FirstOrDefault();
        Domain.Entities.UserAddress billMatch = m_userAddressRepo.UserAddresses.Where(a => a.Line1.ToLower().Equals(bill.Line1.ToLower())).FirstOrDefault();
        
        if (Domain.Entities.UserAddress.Matches(ship, shipMatch))
        {
          ship = shipMatch; // use the one already in the database.
        }
        else{
          ship = m_userAddressRepo.CreateAddress(ship); // Create in database.
        }
        if (Domain.Entities.UserAddress.Matches(bill, billMatch))
        {
          bill = billMatch; // use the one already in the database.
        }
        else{
          bill = m_userAddressRepo.CreateAddress(bill); // Create in database.
        }
      }

      Order order = new Order()
      {
        CreatedAt = DateTime.Now,
        UpdatedAt = DateTime.Now,
        OrderDate = DateTime.Now,
        UserId = m_userId,
        OrderStatus = "Not Shipped Yet",
        ShippingAddress = ship,
        BillingAddress = bill,
        ShippingAddressId = ship.Id,
        BillingAddressId = bill.Id
      };

      List<OrderedProduct> orderedProducts = new List<OrderedProduct>();

      foreach (CartLine cartLine in cart.Lines)
      {
        OrderedProduct orderedProduct = new OrderedProduct(){
          Product = cartLine.Product,
          QtyToOrder = cartLine.Quantity,
          Order = order
        };
        orderedProducts.Add(orderedProduct);
      }
      order.OrderedProducts = orderedProducts;
      
      m_orderRepo.CreateOrder(order);

      cart.Clear();
      return true;
    }
  }
}