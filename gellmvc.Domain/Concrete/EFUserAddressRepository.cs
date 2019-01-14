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
      context.UserAddresses.Add(address);
      context.SaveChanges();
      return address;
    }
  }
}
