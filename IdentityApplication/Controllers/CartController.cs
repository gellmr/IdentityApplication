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
    
    public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
    {
      Product product = repository.Products.FirstOrDefault(p => p.Id == Id);

      if (product != null)
      {
        cart.RemoveLine(product);
      }
      return RedirectToAction("Index", new { returnUrl });
    }
    
    public RedirectToRouteResult ClearCart(Cart cart)
    {
      cart.Clear();
      return RedirectToAction("Index");
    }
    
    public ViewResult Index(Cart cart)
    {
      return View(LookUpProducts(cart));
    }
    
    [HttpPut]
    [Route("Cart/PutUpdate")]
    public HttpStatusCodeResult PutUpdate(Cart cart, CartUpdate cartUpdate)
    {
      // Check if there are sufficient quantity in stock.
      Product product = repository.Products.FirstOrDefault(p => p.Id == cartUpdate.ProductId);

      if (product.QuantityInStock >= cartUpdate.NewQty)
      {
        // We have enough stock...
        if (cartUpdate.NewQty == 0)
        {
          // User set qty to zero.
          cart.RemoveLine(product);
          cartResponseHeaders(cart, "updated-qty", 0, 0, "Updated cart - set qty to zero.");
          return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }
        else
        {
          if (cartUpdate.NewQty > 0)
          {
            // User set qty to positive integer. Update cart quantity.
            Cart.CartLine line = cart.SetLineQuantity(product, cartUpdate.NewQty);
            cartResponseHeaders(cart, "updated-qty", line.Quantity, line.SubTotal, "Updated cart.");
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
          }
          else
          {
            // User set qty to negative integer. Remove from cart.
            cart.RemoveLine(product);
            cartResponseHeaders(cart, "removed-from-cart", 0, 0, "Removed item from cart.");
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
        return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
      }
    }
  }
}