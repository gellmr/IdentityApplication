using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace gellmvc.Domain.Concrete
{
  public class EFProductRepository : IProductRepository
  {
    private EFDbContext context = new EFDbContext();

    public EFProductRepository() { }

    public EFProductRepository(EFDbContext context2){
      context = context2;
    }

    public IEnumerable<Product> Products
    {
      get { return context.Products; }
    }

    public Product GetProductById(int id)
    {
      return context.Products.Find(id);
    }

    public Product GetProductById(int id, DbContext context)
    {
      EFDbContext context2 = (EFDbContext)context;
      return context2.Products.Find(id);
    }

    public IEnumerable<OrderedProduct> GetOrderedProductsByOrderId(int orderId)
    {
      return context.OrderedProducts.Where(op => op.OrderId == orderId);
    }
  }
}
