//-----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Crossover">
// This controller has the responsibility loading the dashboard view.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// Loads the home page of the user.
    /// </summary>
    public class HomeController : Controller
    {
        [Authorize]
        /// <summary>
        /// Renders the home page of the user.
        /// </summary>
        /// <returns>The home page view.</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}