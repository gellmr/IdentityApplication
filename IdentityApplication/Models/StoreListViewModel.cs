using System.Collections.Generic;
using gellmvc.Domain.Entities;

namespace gellmvc.Models
{
  public class StoreListViewModel
  {
    public IEnumerable<ProductLine> ProductLines { get; set; } // Product lines on page.
    public Pager Pager { get; set; }
    public string SearchString { get; set; }
    public bool ShowWelcomeText { get; set; }

    public StoreListViewModel()
    {
      SearchString = "";
      Pager = null;
      ProductLines = null;
      ShowWelcomeText = true;
    }
  }
}