using System.Collections.Generic;
using gellmvc.Domain.Entities;
using System.Linq;

namespace gellmvc.Domain.Abstract
{
  public interface IOrderRepository
  {
    IEnumerable<Order> Orders { get; }
    IEnumerable<OrderedProduct> OrderedProducts { get; }
    IQueryable<Order> GetOrdersByCustomerId(string customerId);
    void CreateOrder(Order order);
  }
}
