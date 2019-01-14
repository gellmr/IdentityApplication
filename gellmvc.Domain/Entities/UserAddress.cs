using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace gellmvc.Domain.Entities
{
  // UserAddresses table
  public class UserAddress
  {
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Line1 { get; set; }

    [MaxLength(50)]
    public string Line2 { get; set; }

    [Required]
    [MaxLength(25)]
    public string City { get; set; }

    [Required]
    [MaxLength(25)]
    public string State { get; set; }

    [Required]
    [MaxLength(25)]
    public string PostCode { get; set; }

    [Required]
    [MaxLength(50)]
    public string CountryOrRegion { get; set; }

    public bool Deleted { get; set; }

    public string OneLine()
    {
      return String.Format("{0} {1} {2} {3} {4}", Line1, City, State, PostCode, CountryOrRegion);
    }

    // Compare fields on UserAddress objects, to check for memberwise equality.
    // You can't call String.toLower() on a null string so I need this method.
    private static bool StringMatch(string a, string b)
    {
      // if both strings == null, then match == true.
      if (a == null && b == null) { return true; }
      
      // if only one string is null, then there is no match.
      if (a == null || b == null) { return false; }

      // both not null...
      return String.Equals(a.ToLower(), b.ToLower());
    }

    public static bool Matches(UserAddress a, UserAddress other)
    {
      if (other == null) { return false; }

      if (
        StringMatch(a.UserId, other.UserId) // belongs to same user
        &&
        StringMatch(a.Line1, other.Line1) // other details the same, case insensitive
        &&
        StringMatch(a.Line2, other.Line2)
        &&
        StringMatch(a.City, other.City)
        &&
        StringMatch(a.State, other.State)
        &&
        StringMatch(a.PostCode, other.PostCode)
        &&
        StringMatch(a.CountryOrRegion, other.CountryOrRegion)
        &&
        a.Deleted == other.Deleted
        )
      {
        return true; // effectively matches the given address.
      }
      return false;
    }
  }
}
