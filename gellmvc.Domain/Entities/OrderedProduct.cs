using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gellmvc.Domain.Entities
{
  // OrderedProducts table
  public class OrderedProduct
  {
    public int Id { get; set; }           // PK

    [Required]
    public int OrderId { get; set; }         // FK
    public virtual Order Order { get; set; } // Navigation

    [Required]
    public int ProductId{ get; set; }            // FK
    public virtual Product Product { get; set; } // Navigation
    
    [Required]
    public int QtyToOrder { get; set; }
  }
}
