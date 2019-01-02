using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace gellmvc.Helpers
{
  public static class ApplicationHelper
  {
    public static string SiteImagesFolderPath()
    {
      return ConfigurationManager.AppSettings["siteImagesFolderPath"].ToString();
    }
    public static string ProductImagesFolder()
    {
      return ConfigurationManager.AppSettings["productImagesFolder"].ToString();
    }
  }
}