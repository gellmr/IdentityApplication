using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityApplication.Startup))]
namespace IdentityApplication
{
  public partial class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      ConfigureAuth(app);
    }
  }
}
