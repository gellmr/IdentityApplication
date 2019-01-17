using gellmvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gellmvc.Models
{
  public class OrderIndexViewModel
  {
    public List<Order> Orders { get; set; }
  }

  public class OrderViewModel
  {
    public Order Order { get; set; }
  }
}