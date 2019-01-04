using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using gellmvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static gellmvc.Domain.Entities.Cart;

namespace gellmvc.Controllers
{
  public abstract class CartBaseController : Controller
  {
    protected IProductRepository repository;

    public CartBaseController(IProductRepository repo){
      repository = repo;
    }
    
    protected CartIndexViewModel LookUpProducts(Cart cart)
    {
      List<ProductLine> productLines = new List<ProductLine>();

      foreach (CartLine cartLine in cart.Lines)
      {
        // Look up the product
        Product product = repository.Products.FirstOrDefault(p => p.ProductId == cartLine.Product.ProductId);
        int qty = cartLine.Quantity;
        productLines.Add(new ProductLine
        {
          Product = product,
          QtyInCart = qty,
          Subtotal = qty * product.UnitPrice
        });
      }

      // Construct the view model
      CartIndexViewModel viewModel = new CartIndexViewModel
      {
        ProductLines = productLines,
        Cart = cart,

        User = "Mike Gell",
        Addresses = new List<Models.UserAddress> {
          //new Models.UserAddress{ Id = 0, Value = "0 Graceful Loop, Swanview", Deleted = false},
          //new Models.UserAddress{ Id = 1, Value = "1 Success Ave Bibra Lake", Deleted = false},
          //new Models.UserAddress{ Id = 2, Value = "2 Grant Street Innaloo", Deleted = false}
        },
        ShippingAddress = 0, // Id of the address to use
        BillingAddress = 0,  // Id of the address to use

        // These will be filled out if the user is creating address for the first time.
        AddressFieldsPOS = new AddressFieldsPOS {
          ShippingAddressPOS = new Models.UserAddress{ },
          sameForBilling = true,
          BillingAddressPOS = new Models.UserAddress { },
        }
      };

      return viewModel;
    }

    // Set some headers on our http response
    protected void cartResponseHeaders(Cart cart, string cartResult, int resultCartQty, decimal resultSubTot, string message)
    {
      Response.AddHeader("result", cartResult.ToString());
      Response.AddHeader("resultCartQty", resultCartQty.ToString());
      Response.AddHeader("resultSubTot", resultSubTot.ToString());
      Response.AddHeader("message", message);

      Response.AddHeader("resultGrandTot", cart.GrandTotal().ToString());
      Response.AddHeader("cartTotalItems", cart.TotalItemsInCart().ToString());
      Response.AddHeader("cartTotalLines", cart.Lines.Count().ToString());
    }
  }
}