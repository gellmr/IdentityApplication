using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gellmvc.Helpers
{
  public class ModelHelpers
  {

    // Convert viewmodel useraddress into domain model user address.
    public static Domain.Entities.UserAddress DomainUserAddress(Models.UserAddress modelUserAddress)
    {
      return new Domain.Entities.UserAddress()
      {
        Line1 = modelUserAddress.Line1,
        Line2 = modelUserAddress.Line2,
        City = modelUserAddress.City,
        State = modelUserAddress.State,
        PostCode = modelUserAddress.PostCode,
        CountryOrRegion = modelUserAddress.CountryOrRegion,
        Deleted = modelUserAddress.Deleted,
        UserId = modelUserAddress.UserId,

        Id = modelUserAddress.Id
      };
    }

    // Convert domain useraddress into viewmodel user address.
    public static Models.UserAddress VMUserAddress(Domain.Entities.UserAddress domainUserAddress)
    {
      return new Models.UserAddress()
      {
        Line1 = domainUserAddress.Line1,
        Line2 = domainUserAddress.Line2,
        City = domainUserAddress.City,
        State = domainUserAddress.State,
        PostCode = domainUserAddress.PostCode,
        CountryOrRegion = domainUserAddress.CountryOrRegion,
        Deleted = domainUserAddress.Deleted,
        UserId = domainUserAddress.UserId,

        Id = domainUserAddress.Id
      };
    }
  }
}