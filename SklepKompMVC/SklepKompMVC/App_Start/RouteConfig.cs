﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SklepKompMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {




            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            





            routes.MapRoute(
           name: "ProductDetails",
                url: "product-{id}",
                defaults: new { controller = "Store", action = "Details" }
                );

            //routes.MapRoute(
            //   name: "AdminPage",
            //   url: "Admin/{controllername}",
            //   defaults: new { controller= "Home", action="AdminPages"}
               
            //    );

            routes.MapRoute(
               name: "StaticPages",
               url: "Site/{viewname}",
               defaults: new { controller = "Home", action = "StaticContent" }
                );



            routes.MapRoute(
               name: "ProductList",
               url: "kategorie/{categoryname}",
               defaults: new { controller = "Store", action = "List" },
               constraints: new { categoryname = @"[\w& ]+" }
                );



            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
