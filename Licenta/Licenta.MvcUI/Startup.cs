using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Licenta.MvcUI.Startup))]
namespace Licenta.MvcUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
