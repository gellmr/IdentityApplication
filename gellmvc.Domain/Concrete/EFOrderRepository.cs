using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

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
      var ctx = new EFDbContext();
      ctx.Orders.Add(order);
      foreach (OrderedProduct op in order.OrderedProducts){
        ctx.OrderedProducts.Add(op);
        ctx.Entry(op.Product).State = EntityState.Unchanged; // Prevent EF from creating new Products
      }
      // Prevent EF from creating new addresses
      ctx.Entry(order).State = EntityState.Added;
      ctx.Entry(order.ShippingAddress).State = EntityState.Unchanged;
      ctx.Entry(order.BillingAddress).State = EntityState.Unchanged;
      ctx.SaveChanges();
    }

    public IEnumerable<Order> GetOrdersByCustomerId(string userId)
    {
      IEnumerable<Order> orders = context.Orders.Where(o => o.UserId.Equals(userId));

      for (int i = 0; i < orders.Count(); i++)
      {
        Order o = orders.ElementAt(i);
        AttachObjectsForOrder(ref o, new EFProductRepository(context));
      }
      return orders;
    }

    public Order GetOrderById(int orderId, IProductRepository productRepo)
    {
      Order order = context.Orders.Find(orderId); // gives us the Order but its OrderedProducts comes back null.

      AttachObjectsForOrder(ref order, productRepo);

      return order;
    }

    // EF does not automatically look up and attach the nested objects, so we do it here.
    //
    private void AttachObjectsForOrder(ref Order order, IProductRepository productRepo)
    {
      // Look up the OrderedProducts
      order.OrderedProducts = productRepo.GetOrderedProductsByOrderId(order.Id);

      // The Order and Product of each OrderedProduct come through as null, so I need to look them up and attach to object.
      // Here I have used a for loop instead of foreach loop, because it was hitting a problem with lazy loading when we try to look up the product.
      for (int i = 0; i < order.OrderedProducts.Count(); i++)
      {
        //foreach (OrderedProduct op in order.OrderedProducts)
        OrderedProduct op = order.OrderedProducts.ElementAt(i);
        op.Order = order;
        op.Product = productRepo.GetProductById(op.ProductId, context);
      }

      // Look up the shipping and billing address objects.
      EFUserAddressRepository addressRepo = new EFUserAddressRepository();
      order.ShippingAddress = addressRepo.GetAddressById(order.ShippingAddressId);
      order.BillingAddress  = addressRepo.GetAddressById(order.BillingAddressId);
    }
  }
}
