using System.Linq;
using System.Web.Mvc;
using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using gellmvc.Models;

namespace gellmvc.Controllers
{
  public class CartController : CartBaseController
  {
    public CartController(IProductRepository repo) : base (repo) {}
    
    public RedirectToRouteResult ClearCart(Cart cart)
    {
      cart.Clear();
      return RedirectToAction("Index");
    }

    public ViewResult Index(CartIndexViewModel model)
    {
      return View(LookUpProducts(model));
    }
    
    [HttpPut]
    [Route("Cart/PutUpdate")]
    public HttpStatusCodeResult PutUpdate(CartUpdate cartUpdate)
    {
      // Check if there are sufficient quantity in stock.
      Product product = repository.Products.FirstOrDefault(p => p.ProductId == cartUpdate.ProductId);
      Cart cart = GetSessionCart();

      if (product.QuantityInStock >= cartUpdate.NewQty)
      {
        // We have enough stock...
        if (cartUpdate.NewQty == 0)
        {
          // User set qty to zero.
          //cart.RemoveLine(product);
          cartResponseHeaders(cart, "updated-qty", 0, 0, "Updated cart - set qty to zero.");
          SaveSessionCart(cart);
          return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        else
        {
          if (cartUpdate.NewQty > 0)
          {
            // User set qty to positive integer. Update cart quantity.
            Cart.CartLine line = cart.SetLineQuantity(product, cartUpdate.NewQty);
            cartResponseHeaders(cart, "updated-qty", line.Quantity, line.SubTotal, "Updated cart.");
            SaveSessionCart(cart);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
          }
          else
          {
            // User set qty to negative integer. Remove from cart.
            cart.RemoveLine(product);
            cartResponseHeaders(cart, "removed-from-cart", 0, 0, "Removed item from cart.");
            SaveSessionCart(cart);
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
          }
        }
      }
      else
      {
        // User wants more than we have available. Set to max available.
        Cart.CartLine line = cart.SetLineQuantity(product, product.QuantityInStock);
        Response.AddHeader("max", product.QuantityInStock.ToString());
        cartResponseHeaders(cart,
          "set-to-max",
          product.QuantityInStock,
          product.UnitPrice * product.QuantityInStock,
          "Only " + product.QuantityInStock + " items available!"
        );
        SaveSessionCart(cart);
        return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
      }
    }
  }
}