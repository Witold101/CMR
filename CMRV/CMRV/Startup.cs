using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMRV.Startup))]
namespace CMRV
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
