using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace sistalabben
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("ContactCreate", "kund/ny", "~/Pages/ContactPages/Create.aspx");

            routes.MapPageRoute("ContactListing", "kund/lista", "~/Pages/ContactPages/Listing.aspx");
            routes.MapPageRoute("ContactEdit", "kund/{id}/redigera", "~/Pages/ContactPages/Edit.aspx");
            routes.MapPageRoute("ContactDelete", "kund/{id}/radera", "~/Pages/ContactPages/Delete.aspx");

            routes.MapPageRoute("Error", "serverfel", "~/Pages/Shared/Error.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/ContactPages/Listing.aspx");
        }
    }
}