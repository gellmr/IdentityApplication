using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gellmvc.Domain.Entities;

namespace gellmvc.Controllers
{
  public abstract class ShoppingController : Controller
  {
    public Cart GetSessionCart()
    {
      if (Session["Cart"] == null) {
        Session["Cart"] = new Cart();
      }

      Cart cart = (Cart)Session["Cart"];
      return cart;
    }

    public void SaveSessionCart(Cart cart) {
      Session["Cart"] = cart;
    }
  }
}