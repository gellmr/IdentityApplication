using System.Collections.Generic;
using gellmvc.Domain.Entities;

namespace gellmvc.Domain.Abstract
{
  public interface IUserAddressRepository
  {
    IEnumerable<UserAddress> UserAddresses { get; }
    UserAddress CreateAddress(UserAddress address);
  }
}
