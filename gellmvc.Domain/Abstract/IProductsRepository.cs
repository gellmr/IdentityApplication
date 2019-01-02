using System.Collections.Generic;
using gellmvc.Domain.Entities;

namespace gellmvc.Domain.Abstract
{
  public interface IProductRepository
  {
    IEnumerable<Product> Products { get; }
  }
}
