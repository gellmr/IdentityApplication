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

namespace gellmvc.Controllers
{
  public class OrderController : Controller
  {
    protected IUserAddressRepository userAddressRepo;

    public OrderController(IUserAddressRepository userAddyRepo){
      userAddressRepo = userAddyRepo;
    }

    // need to get the model binding to work on CartIndexViewModel
    //
    // https://www.pluralsight.com/guides/asp-net-mvc-getting-default-data-binding-right-for-hierarchical-views
    //
    [HttpPost]
    public ActionResult Create(CartIndexViewModel model)
    {
      Debug.WriteLine("Try to create an order...");
      if (UserGotAddresses(model) == false)
      {
        Debug.WriteLine("User has got no addresses");
        TempData["flashDanger"] = "Please provide your Shipping and Billing address information.";
        return RedirectToAction("Index", "Checkout");
      }
      else
      {
        Debug.WriteLine("User has got an address...");

        if (PlaceOrder(model))
        {
          Debug.WriteLine("Order created successfully.");
          TempData["flashSuccess"] = "Your order was created successfully.";
        }
        else
        {
          Debug.WriteLine("Could not create order.");
          TempData["flashDanger"] = "Could not create order.";
        }
        return View("Show");
      }
    }

    private bool PlaceOrder(CartIndexViewModel model)
    {
      bool all_valid = true;
      // need an orders repo to do the work.
      return false;
    }

    private bool UserGotAddresses(CartIndexViewModel model)
    {
      string userId = User.Identity.GetUserId();

      // Get the addresses for this user.
      List<Domain.Entities.UserAddress> userAddresses = userAddressRepo.UserAddresses.Where(a => a.UserId.ToString() == userId).ToList();
      if (userAddresses.Count() > 0) {
        return true; // user has got addresses
      }

      // todo: use model validation here
      if (String.IsNullOrEmpty(model.AddressFieldsPOS.ShippingAddressPOS.Line1))
      {
        return false; // user failed to fill out shipping address line 1
      }
      if (model.AddressFieldsPOS.sameForBilling == false && String.IsNullOrEmpty(model.AddressFieldsPOS.BillingAddressPOS.Line1))
      {
        return false; // user failed to fill out billing address line 1
      }
      return true; // user has provided address details at point of sale.
    }
  }
}