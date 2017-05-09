using System.Web.Mvc;
using System.Web.Routing;

namespace Application
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "AuctionOpen",
                url: "auction/lot/{id}",
                defaults: new { controller = "Auction", action = "Open" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Category",
                "Category/{categoryId}",
                new { controller = "Home", action = "Category" }
            );
        }
    }
}
