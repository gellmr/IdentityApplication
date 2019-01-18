using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Web.Mvc;
using gellmvc.Models;
using static gellmvc.Domain.Entities.Cart;
using gellmvc.Domain.Concrete;
using Microsoft.AspNet.Identity;
using gellmvc.Helpers;

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
      CartIndexViewModel vm = LookUpProducts(model);
      EFUserAddressRepository addressRepo = new EFUserAddressRepository();
      IEnumerable<Domain.Entities.UserAddress> addresses = addressRepo.LookUpAddressesForUser(User.Identity.GetUserId());
      List<Models.AddressRowViewModel> vmAddresses = new List<Models.AddressRowViewModel>();
      for (var i = 0; i < addresses.Count(); i++){
        vmAddresses.Add(new AddressRowViewModel {
          UserAddress = ModelHelpers.VMUserAddress(addresses.ElementAt(i))
        });
      }
      vm.Addresses = vmAddresses;
      return View(vm);
    }
  }
}