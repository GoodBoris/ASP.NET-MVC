using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoAlbum.WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Photo",
                    action = "List",
                    currentUser = (string)null,
                    page = 1
                }
            );

            routes.MapRoute(
                name: "Profile",
                url: "{currentUser}/Profile/{action}",
                defaults: new { controller = "Profile", action = "Index" });

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "Photo", action = "List", currentUser = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(null, url: "{userPhotos}", defaults: new { controller = "Photo", action = "List", page = 1 }
            );

            routes.MapRoute(null,
                "{userPhotos}/Page{page}",
                new { controller = "Photo", action = "List" },
                new { page = @"\d+" }
            );
            routes.MapRoute(null, "{currentUser}/manage", new {controller = "Photo", action = "Manage"});
            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
