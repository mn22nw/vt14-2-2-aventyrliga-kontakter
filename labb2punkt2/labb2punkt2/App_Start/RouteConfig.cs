using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace labb2punkt2.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ContactCreate", "Kund/ny", "~/Create.aspx");

            routes.MapPageRoute("Default", "", "~/Default.aspx");
        }
    }
}