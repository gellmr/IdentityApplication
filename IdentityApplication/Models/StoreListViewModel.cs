using System.Collections.Generic;
using gellmvc.Domain.Entities;

namespace gellmvc.Models
{
  public class StoreListViewModel
  {
    public IEnumerable<ProductLine> ProductLines { get; set; }
    public Pager Pager { get; set; }
    public Cart Cart { get; set; }
    public string SearchString { get; set; }
  }
}