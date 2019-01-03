using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gellmvc.Domain.Entities;

namespace gellmvc.Models
{
  public class CartIndexViewModel
  {
    public IEnumerable<ProductLine> ProductLines { get; set; }
    public Cart Cart { get; set; }

    public string User { get; set; }
    public IEnumerable<UserAddress> Addresses { get; set; }

    public int ShippingAddress { get; set; } // Id of the address object
    public int BillingAddress { get; set; }  // Id of the address object
  }

  public class CartUpdate
  {
    public int ProductId { get; set; }
    public int NewQty { get; set; }
  }

  public class UserAddress
  {
    public int Id { get; set; }
    public string Value { get; set; }
    public bool Deleted { get; set; }
  }

  public class AddressRowViewModel
  {
    public string User { get; set; }
    public UserAddress UserAddress { get; set; }
    public bool IsShipping { get; set; }
    public bool IsBilling { get; set; }
  }
}