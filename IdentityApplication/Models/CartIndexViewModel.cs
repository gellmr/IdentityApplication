using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gellmvc.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

    public AddressFieldsPOS AddressFieldsPOS { get; set; } // if the user has no addresses, they must fill out these input fields at the point of sale to create new shipping and billing address.
  }

  public class AddressFieldsPOS
  {
    public Models.UserAddress ShippingAddressPOS { get; set; }
    public bool sameForBilling { get; set; }
    public Models.UserAddress BillingAddressPOS { get; set; }
  }

  public class CartUpdate
  {
    public int ProductId { get; set; }
    public int NewQty { get; set; }
  }

  public class UserAddress
  {
    [Key]
    public int Id { get; set; }

    public int UserId { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "Address Line 1")]
    public string Line1 { get; set; }

    [MaxLength(50)]
    [Display(Name = "Address Line 2")]
    public string Line2 { get; set; }

    [MaxLength(25)]
    [Display(Name = "City")]
    public string City { get; set; }

    [MaxLength(25)]
    [Display(Name = "State")]
    public string State { get; set; }

    [MaxLength(25)]
    [Display(Name = "PostCode")]
    public string PostCode { get; set; }

    [MaxLength(50)]
    [Display(Name = "Country or Region")]
    public string CountryOrRegion { get; set; }

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