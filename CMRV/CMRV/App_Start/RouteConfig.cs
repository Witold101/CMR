using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CMRV
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "lang",
                url: "{lang}/{controller}/{action}/{id}",
                defaults: new {lang="Ru", controller = "Home", action = "Index", id = UrlParameter.Optional },
                constraints: new { lang = @"ru|en|pl" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new {lang = "Ru", controller = "Home", action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}
