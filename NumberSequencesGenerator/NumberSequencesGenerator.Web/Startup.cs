using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NumberSequencesGenerator.Web.Startup))]
namespace NumberSequencesGenerator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
