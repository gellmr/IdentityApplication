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
    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    [Required]
    [MaxLength(25)]
    public string OrderStatus { get; set; }
    
    public UserAddress ShippingAddressId { get; set; }  // FK
    
    public UserAddress BillingAddressId { get; set; }   // FK
    
    public IEnumerable<OrderedProduct> OrderedProducts { get; set; }
  }
}
