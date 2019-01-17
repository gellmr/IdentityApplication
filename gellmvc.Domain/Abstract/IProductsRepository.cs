using System.Collections.Generic;
using System.Data.Entity;
using gellmvc.Domain.Entities;

namespace gellmvc.Domain.Abstract
{
  public interface IProductRepository
  {
    IEnumerable<Product> Products { get; }
    Product GetProductById(int id);
    Product GetProductById(int id, DbContext context);
    IEnumerable<OrderedProduct> GetOrderedProductsByOrderId(int orderId);
  }
}
