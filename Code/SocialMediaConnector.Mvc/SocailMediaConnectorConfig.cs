using System.Web.Routing;
using SocialMediaConnector.Mvc;
using WebActivatorEx;
using SocialMediaConnector.Core;
using SocialMediaConnector.Mvc;

[assembly: PreApplicationStartMethod(typeof (SocailMediaConnectorConfig), "RegisterRoutes")]

namespace SocialMediaConnector.Mvc
{
    public static class SocailMediaConnectorConfig
    {
        public static void RegisterRoutes()
        {
            // Do we have any custom routes defined?
            if (AuthenticationProviderFactory.Configuration.Value == null)
            {
                SocialMediaConnectorRouteConfig.RegisterDefaultRoutes(RouteTable.Routes);
            }
            else
            {
                SocialMediaConnectorRouteConfig.RegisterDefaultRoutes(RouteTable.Routes,
                                                                      AuthenticationProviderFactory.Configuration.Value
                                                                                                   .RedirectRoute,
                                                                      AuthenticationProviderFactory.Configuration.Value
                                                                                                   .CallBackRoute);
            }
        }
    }
}