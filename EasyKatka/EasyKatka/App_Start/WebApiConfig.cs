using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EasyKatka
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "AuthenticationApiController_LogIn",
                "api/authentication/login",
                new { controller = "AuthenticationApi", action = "LogIn" }
            );

            config.Routes.MapHttpRoute(
                "AuctionApiController_GetAuctions",
                "api/auction/getAuctions",
                new { controller = "AuctionApi", action = "GetAuctions" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
