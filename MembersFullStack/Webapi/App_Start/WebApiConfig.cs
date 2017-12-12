using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using CBHS.Business.Interfaces;
using CBHS.Business;
using SimpleInjector.Integration.WebApi;
using CBHS.Datasource;

namespace CBHS.Webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "Members", id = RouteParameter.Optional }
            );

            var container = new SimpleInjector.Container();

            container.Register<IMemberService, MemberService>();
            container.Register<IDataRepository, DataRepository>();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}