using gellmvc.Domain.Abstract;
using gellmvc.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace gellmvc.Domain.Concrete
{
  public class EFUserAddressRepository : IUserAddressRepository
  {
    // Read only
    public IQueryable<UserAddress> ro_UserAddresses
    {
      get {
        var ctx = new EFDbContext();
        return ctx.UserAddresses.AsNoTracking();
      }
    }

    // Read only
    public UserAddress ro_GetAddressById(int? id)
    {
      var ctx = new EFDbContext();
      if (id == null) { return null; }
      return ctx.UserAddresses.AsNoTracking().FirstOrDefault(a => a.Id == id) as UserAddress;
    }

    // Read only
    public IEnumerable<UserAddress> ro_LookUpAddressesForUser(string userId)
    {
      EFDbContext ctx = new EFDbContext();
      ctx.Configuration.AutoDetectChangesEnabled = false;
      return ctx.UserAddresses.Where(a => a.UserId.Equals(userId)) as IEnumerable<UserAddress>;
    }

    public UserAddress CreateAddress(UserAddress address)
    {
      var ctx = new EFDbContext();
      ctx.UserAddresses.Add(address);
      ctx.SaveChanges();
      return address;
    }
  }
}
