using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SocialMediaConnector.Core;
using SocialMediaConnector.Mvc;
using SocialMediaConnector.MvcAuto.App_Start;
using SocialMediaConnector.MvcAuto.Controllers;
using SocialMediaConnector.Mvc;
using SocialMediaConnector.Mvc.Caching;


namespace SocialMediaConnector.MvcAuto
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var builder = new ContainerBuilder();

            builder.RegisterType<SampleMvcAutoAuthenticationCallbackProvider>().As<IAuthenticationCallbackProvider>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(SocialMediaConnectorController).Assembly);
            builder.RegisterType<CookieCache>().As<ICache>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}