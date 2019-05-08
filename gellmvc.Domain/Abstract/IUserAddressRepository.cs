using System.Collections.Generic;
using System.Linq;
using gellmvc.Domain.Entities;

namespace gellmvc.Domain.Abstract
{
  public interface IUserAddressRepository
  {
    IQueryable<UserAddress> ro_UserAddresses { get; }
    UserAddress CreateAddress(UserAddress address);
    UserAddress ro_GetAddressById(int? id);
  }
}
