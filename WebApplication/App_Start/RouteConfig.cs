using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication.App_Code;

namespace WebApplication
{
    public class RouteConfig
    {
        public static Dictionary<string, string> Routes = new Dictionary<string, string>();

        public static void RegisterRoutes()
        {
            Routes.Add("Home", "Index");
            Routes.Add("Order", "Orders");
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            RegisterRoutes();
            Route newRoute = new Route("Home/Index", new MyRouteHandler());
            routes.Add(newRoute);
            newRoute= new Route("Order/GetData", new MyRouteHandler());
            routes.Add(newRoute);

        }
    }
}
