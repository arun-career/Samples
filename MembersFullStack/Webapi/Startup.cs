using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CBHS.Webapi.Startup))]

namespace CBHS.Webapi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
