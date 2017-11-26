using Owin;
using System.Web.Http;

namespace MicroConsole
{
    public class StartUp
    {
        //This code configues Web API. The start up class is specified as a type
        //parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            //Configure Web API for self-host
            HttpConfiguration config = new HttpConfiguration();
            config.EnableCors();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{isbn}",
                defaults: new { isbn = RouteParameter.Optional } 
                );

            appBuilder.UseWebApi(config);
        }
    }
}
