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
        /// <summary>
        /// Renders the home page of the user.
        /// </summary>
        /// <returns>The home page view.</returns>
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Renders the about page of the company.
        /// </summary>
        /// <returns>The about page view.</returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}