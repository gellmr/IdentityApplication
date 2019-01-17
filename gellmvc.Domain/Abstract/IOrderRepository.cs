using System.Collections.Generic;
using gellmvc.Domain.Entities;
using System.Linq;
using gellmvc.Domain.Concrete;

namespace gellmvc.Domain.Abstract
{
  public interface IOrderRepository
  {
    IEnumerable<Order> Orders { get; }
    IEnumerable<OrderedProduct> OrderedProducts { get; }
    void CreateOrder(Order order);
    IEnumerable<Order> GetOrdersByCustomerId(string userId);
    Order GetOrderById(int orderId, IProductRepository productRepo);
  }
}
