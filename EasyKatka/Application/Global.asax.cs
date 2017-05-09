using Application.App_Start;
using Application.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
