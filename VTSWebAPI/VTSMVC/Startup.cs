using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VTSMVC.Startup))]
namespace VTSMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
