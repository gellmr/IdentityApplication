using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;

namespace gellmvc.Domain.Concrete
{
  public class EFUserAddressRepository : IUserAddressRepository
  {
    private EFDbContext context = new EFDbContext();

    public IEnumerable<UserAddress> UserAddresses
    {
      get { return context.UserAddresses; }
    }
    
    public UserAddress CreateAddress(UserAddress address)
    {
      var ctx = new EFDbContext();
      ctx.UserAddresses.Add(address);
      ctx.SaveChanges();
      return address;
    }

    public UserAddress GetAddressById(int? id)
    {
      if (id == null) { return null; }
      return context.UserAddresses.Find(id);
    }
  }
}
