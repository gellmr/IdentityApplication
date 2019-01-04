using System.Collections.Generic;
using gellmvc.Domain.Entities;

namespace gellmvc.Domain.Abstract
{
  public interface IOrderRepository
  {
    IEnumerable<Order> Orders { get; }
  }
}
