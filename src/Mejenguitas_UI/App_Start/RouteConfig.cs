using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mejenguitas_UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: null,
                url: "Administration",
                defaults: new {controller = "Juego", action = "List" },
                constraints: null,
                namespaces: new[] { "Mejenguitas_UI.Areas.Administration.Controllers" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}",
                defaults: new {controller = "Juego", action = "List"}
            );
        }
    }
}