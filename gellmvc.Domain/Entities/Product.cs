using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gellmvc.Domain.Entities
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal CostFromSupplier { get; set; }
    public int QuantityInStock { get; set; }
    public DateTime CreatedAt { get; set; }
  }

  public class ProductLine
  {
    public Product Product { get; set; }
    public int QtyInCart { get; set; }
    public decimal Subtotal { get; set; }
  }
}
