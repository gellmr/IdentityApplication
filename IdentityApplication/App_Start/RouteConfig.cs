using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IdentityApplication
{
  public class RouteConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: null,
        url: "Page{page}",
        defaults: new { Controller = "Store", action = "Index" }
      );

      routes.MapRoute(
        name: null,
        url: "Home/Index",
        defaults: new { Controller = "Store", action = "Search" }
      );

      routes.MapRoute(
        name: null,
        url: "Home",
        defaults: new { Controller = "Store", action = "Search" }
      );

      routes.MapRoute(
        name: null,
        url: "Store/Index",
        defaults: new { Controller = "Store", action = "Search" }
      );

      routes.MapRoute(
        name: "Default",
        url: "{controller}/{action}/{id}",
        defaults: new { controller = "Store", action = "Search", id = UrlParameter.Optional }
      );
    }
  }
}
