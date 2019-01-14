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
    public AddressMode addressMode = AddressMode.PointOfSale;
    public enum AddressMode
    {
      SelectFromExisting, // user has selected from their existing addresses
      PointOfSale         // user has entered address information at the point of sale
    }
    public AddressFieldsPOS AddressFieldsPOS { get; set; } // If the user fills out address fields at the point of sale, (eg checkout) this object will have the details for shipping and billing address entered.

    public string User { get; set; }

    public IEnumerable<ProductLine> ProductLines { get; set; } // the current page of products we are viewing in the store

    public Cart ReadOnlyCart { get; set; }

    public IEnumerable<UserAddress> Addresses { get; set; }    // stored against this user in the database. Used for shipping and billing.
    public int ShippingAddressIdx { get; set; } // id to use if we are using an address from the database
    public int BillingAddressIdx { get; set; }  // id to use if we are using an address from the database
    
    public CartIndexViewModel()
    {
      AddressFieldsPOS = new AddressFieldsPOS();
      User = "Mike Gell";
      ProductLines = new List<ProductLine>();
      Addresses = new List<UserAddress>();
      ShippingAddressIdx = 0; // use the first item in Addresses if available.
      BillingAddressIdx = 0;  // use the first item in Addresses if available.
    }

    // returns true if a shipping and billing address have been selected/provided.
    public bool ValidAddress()
    {
      if (Addresses.Count() > 0)
      {
        addressMode = AddressMode.SelectFromExisting;
        return true;
      }
      else
      {
        // AddressMode == PointOfSale

        if (String.IsNullOrEmpty(AddressFieldsPOS.ShippingAddressPOS.Line1))
        {
          return false; // no POS shipping address was provided
        }
        if (String.IsNullOrEmpty(AddressFieldsPOS.BillingAddressPOS.Line1))
        {
          return false; // no POS billing address was provided
        }
        return true; // POS address details were provided.
      }
    }

    // Returns the selected shipping address, or the details entered at point of sale.
    public UserAddress ShippingAddress()
    {
      if (addressMode == AddressMode.SelectFromExisting)
      {
        return Addresses.FirstOrDefault(a => a.Id == ShippingAddressIdx);
      } else {
        return AddressFieldsPOS.ShippingAddressPOS;
      }
    }

    // Returns the selected billing address, or the details entered at point of sale.
    public UserAddress BillingAddress()
    {
      if (addressMode == AddressMode.SelectFromExisting)
      {
        return Addresses.FirstOrDefault(a => a.Id == BillingAddressIdx);
      }
      else
      {
        return AddressFieldsPOS.BillingAddressPOS;
      }
    }
  }

  public class AddressFieldsPOS
  {
    public Models.UserAddress ShippingAddressPOS { get; set; }
    public bool sameForBilling { get; set; }
    public Models.UserAddress BillingAddressPOS { get; set; }
    public AddressFieldsPOS()
    {
      ShippingAddressPOS = new Models.UserAddress { };
      BillingAddressPOS = new Models.UserAddress { };
      sameForBilling = true;
    }
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