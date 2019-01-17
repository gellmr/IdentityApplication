using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gellmvc.Domain.Entities
{
  // Orders table
  public class Order
  {
    public int Id { get; set; }               // PK

    [Required]
    public string UserId { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required]
    [MaxLength(25)]
    public string OrderStatus { get; set; }

    public int? ShippingAddressId { get; set; }         // FK
    public UserAddress ShippingAddress { get; set; }    // Navigation
    
    public int? BillingAddressId { get; set; }          // FK
    public UserAddress BillingAddress { get; set; }     // Navigation

    public IEnumerable<OrderedProduct> OrderedProducts { get; set; }

    // The total number of items in the order. Eg 2 lines of 5 items == 10
    public int GetTotalItems(){
      if (OrderedProducts == null) { return 0; }
      int count = 0;
      foreach (OrderedProduct op in OrderedProducts){
        count += op.QtyToOrder;
      }
      return count;
    }

    // The monetary total for this order.
    public decimal GrandTotal(){
      if (OrderedProducts == null) { return 0; }
      decimal total = 0;
      foreach (OrderedProduct op in OrderedProducts){
        total += op.Product.UnitPrice * op.QtyToOrder;
      }
      return total;
    }

    // Eg 2 product lines
    public int ProductLinesCount(){
      if (OrderedProducts == null ) { return 0; }
      return OrderedProducts.Count();
    }
  }
}
