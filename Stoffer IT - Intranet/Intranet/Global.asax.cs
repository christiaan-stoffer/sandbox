
using System.Web.Mvc;
using System.Web.Routing;

namespace Intranet
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.image/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute("Customers", "klanten", new {controller = "Customers", action = "Index"});

            routes.MapRoute("Customer", "klanten/{name}/{action}", new { controller = "Customer", action = "Index", name = string.Empty });

            routes.MapRoute("CustomerFiles1043", "klanten/{name}/bestand/{*filepath}", new { controller = "Customer", action = "GetFile", name = string.Empty, filepath = string.Empty });
            routes.MapRoute("CustomerFiles1033", "klanten/{name}/file/{*filepath}", new { controller = "Customer", action = "GetFile", name = string.Empty, filepath = string.Empty });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}