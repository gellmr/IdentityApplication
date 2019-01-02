using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;

namespace gellmvc.Domain.Concrete
{
  public class EFProductRepository : IProductRepository
  {
    private EFDbContext context = new EFDbContext();

    public IEnumerable<Product> Products
    {
      get { return context.Products; }
    }
  }
}
