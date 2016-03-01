using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Data.Layer;

namespace GameDay
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute(Constant.Route.IgnoreRoute);

            routes.MapRoute(
                name: Constant.Route.Default,
                url: Constant.Route.DefaultUrl,
                defaults: new { controller = Constant.Controller.Account, action = Constant.Controller.Login, id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: Constant.Route.Home,
                url: Constant.Route.DefaultUrl,
                defaults: new { controller = Constant.Controller.Home, action = Constant.Controller.Index, id = UrlParameter.Optional }
            );
        }
    }
}
