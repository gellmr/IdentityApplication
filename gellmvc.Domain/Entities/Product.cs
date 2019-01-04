using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gellmvc.Domain.Entities
{
  // Products table
  public class Product
  {
    public int ProductId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    
    public string ImageUrl { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    [Required]
    public decimal UnitPrice { get; set; }

    [Required]
    public decimal CostFromSupplier { get; set; }

    [Required]
    public int QuantityInStock { get; set; }

    public DateTime CreatedAt { get; set; }
  }
  
  // not in database.
  public class ProductLine
  {
    [Required]
    public Product Product { get; set; }

    [Required]
    public int QtyInCart { get; set; }

    [Required]
    public decimal Subtotal { get; set; }
  }
}
