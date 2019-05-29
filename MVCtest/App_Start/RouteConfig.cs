using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCtest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            //routes.MapRoute(
            //    name: "MemberCenter",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "MemberCenter", action = "index", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "Product",
            //    url: "{controller}/Index/"+ UrlParameter.Optional
            //    //defaults: new { controller = "Product", action = "index", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "ProductC",
            //    url: "Product/category/" + UrlParameter.Optional
            //);
            //routes.MapRoute(
            //    name: "Cart",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Cart", action = "Cart", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    "getProduct",
            //    "api/dashboardMember/{action}",
            //    new { controller = "dashboardMember"}
            //);
        }
    }
}
