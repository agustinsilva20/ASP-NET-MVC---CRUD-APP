﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistemaWebVuelos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

           routes.MapRoute(
               name: "Detalle",
               url: "{controller}/{action}/{matricula}",
               defaults: new { controller = "Vuelo", action = "Detalle"}
           );

            routes.MapRoute(
               name: "destino",
               url: "{controller}/{action}/{destino}",
               defaults: new { controller = "Vuelo", action = "Destino" }
           );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
