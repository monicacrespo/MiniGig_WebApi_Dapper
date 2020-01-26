namespace MiniGigWebApi
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", // to enable multiple actions with the same http method
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}