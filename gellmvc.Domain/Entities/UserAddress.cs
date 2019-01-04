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
    public int UserId { get; set; }

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
  }
}
