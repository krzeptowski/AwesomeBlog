using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "PokazWpisy",
                "Home/Index/{offset}",
                new { controller = "Home", action = "Index", offset = UrlParameter.Optional }
                );
            
            routes.MapRoute(
                "PokazWpisyShort",
                "{offset}",
                new { controller = "Home", action = "Index", offset = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Archiwum",
                "Home/Index/{year}/{month}",
                new {controller="Home", action = "Archive", year = UrlParameter.Optional, month=UrlParameter.Optional}
                );

            routes.MapRoute(
                "PokazPoTagu",
                "Home/Tag/{tag}",
                new { controller = "Home", action = "Tag", tag = UrlParameter.Optional }
                );

            routes.MapRoute(
                "PokazPoTytule",
                "Pokaz/{tytul}",
                new { controller = "Post", action = "Pokaz", tytul = UrlParameter.Optional }
                );

            routes.MapRoute(
                "PokazStrone",
                "Page/{tytul}",
                new { controller = "Page", action = "Show", tytul = UrlParameter.Optional }
                );

            routes.MapRoute(
                "UsunKomentarz",
                "Admin/DeleteComment/{id},{idPost}",
                new { controller = "Admin", action = "DeleteComment", id = UrlParameter.Optional, idPost = UrlParameter.Optional }
                );

            routes.MapRoute(
                "PokazPoDacie",
                "Home/ArchiveByDay/{entryDate}",
                new { controller = "Home", action = "ArchiveByDay"}
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}