using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

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

    public IEnumerable<UserAddress> LookUpAddressesForUser(string userId)
    {
      EFDbContext ctx = new EFDbContext();
      return ctx.UserAddresses.Where(a => a.UserId.Equals(userId)) as IEnumerable<UserAddress>;
    }
  }
}
