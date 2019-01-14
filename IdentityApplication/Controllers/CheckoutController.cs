using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Web.Mvc;
using gellmvc.Models;
using static gellmvc.Domain.Entities.Cart;

namespace gellmvc.Controllers
{
  public class CheckoutController : CartBaseController
  {
    public CheckoutController(IProductRepository repo) : base (repo) {}
    
    public ViewResult Index(CartIndexViewModel model)
    {
      // If we have just been redirected here after logging in
      if (TempData["CartIndexViewModel"] != null){
        model = (CartIndexViewModel)TempData["CartIndexViewModel"];
      }

      return View(LookUpProducts(model));
    }
  }
}