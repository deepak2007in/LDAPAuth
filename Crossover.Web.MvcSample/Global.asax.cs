//-----------------------------------------------------------------------
// <copyright file="MvcApplication.cs" company="Crossover">
// This class has the responsibility of managing the life-cycle events of the application.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.MvcSample
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// Starts the application with the all the configurations.
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Starts the application.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}