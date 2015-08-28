//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="Crossover">
// This class has the responsibility of managing the application routing information.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Manages the routing information of the application.
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// Registers the routes of the application.
        /// </summary>
        /// <param name="routes">The collection of route.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
