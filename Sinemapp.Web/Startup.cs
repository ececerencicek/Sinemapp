using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sinemapp.Web.Startup))]
namespace Sinemapp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
