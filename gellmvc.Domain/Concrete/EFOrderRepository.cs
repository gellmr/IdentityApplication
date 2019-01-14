using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace gellmvc.Domain.Concrete
{
  public class EFOrderRepository : IOrderRepository
  {
    private EFDbContext context = new EFDbContext();

    public IEnumerable<Order> Orders
    {
      get { return context.Orders; }
    }

    public IEnumerable<OrderedProduct> OrderedProducts
    {
      get { return context.OrderedProducts; }
    }

    public void CreateOrder(Order order)
    {
      context.Orders.Add(order);
      foreach (OrderedProduct op in order.OrderedProducts){
        context.OrderedProducts.Add(op);
      }
      context.SaveChanges();
    }

    public IQueryable<Order> GetOrdersByCustomerId(string userId)
    {
      return context.Orders.Where(o => o.UserId.Equals(userId));
    }
  }
}
