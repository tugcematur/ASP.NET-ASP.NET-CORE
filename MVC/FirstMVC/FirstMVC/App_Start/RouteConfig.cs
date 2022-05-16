using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstMVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // core da json olarak gelir.Kendi anlayacağı formatta yazar. id opsiyonel
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }   //Varsayılan
            );
        }
    }
}
