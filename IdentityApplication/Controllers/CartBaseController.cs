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
  public abstract class CartBaseController : ShoppingController
  {
    protected IProductRepository repository;

    public CartBaseController(IProductRepository repo){
      repository = repo;
    }
    
    protected CartIndexViewModel LookUpProducts(CartIndexViewModel cartIndexVM)
    {
      List<ProductLine> cartProducts = new List<ProductLine>();
      Cart cart = GetSessionCart();

      if (cartIndexVM != null)
      {
        // Look up all the products in the cart.
        foreach (CartLine cartLine in cart.Lines)
        {
          Product productInCart = repository.Products.FirstOrDefault(p => p.ProductId == cartLine.Product.ProductId);

          // Get their quantity
          int quantityInCart = cartLine.Quantity;

          cartProducts.Add(new ProductLine
          {
            Product = productInCart,
            QtyInCart = quantityInCart,
            Subtotal = quantityInCart * productInCart.UnitPrice
          });
        }
      }

      if (cartIndexVM == null)
      {
        // Construct the view model
        cartIndexVM = new CartIndexViewModel
        {
          Addresses = new List<Models.UserAddress>
          {
            //new Models.UserAddress{ Id = 0, Value = "0 Graceful Loop, Swanview", Deleted = false},
            //new Models.UserAddress{ Id = 1, Value = "1 Success Ave Bibra Lake", Deleted = false},
            //new Models.UserAddress{ Id = 2, Value = "2 Grant Street Innaloo", Deleted = false}
          }
        };
      }

      cartIndexVM.ProductLines = cartProducts; // this is the current page of products being viewed
      cartIndexVM.ReadOnlyCart = cart;
      return cartIndexVM;
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