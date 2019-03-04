using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcStore.Web.Startup))]
namespace MvcStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
