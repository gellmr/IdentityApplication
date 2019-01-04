using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;

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
  }
}
