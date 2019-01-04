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
    public Order Order { get; set; }      // FK

    [Required]
    public Product Product { get; set; }  // FK

    [Required]
    public int ProductQty { get; set; }
  }
}
