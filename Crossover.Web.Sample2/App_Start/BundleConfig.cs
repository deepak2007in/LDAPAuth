//-----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="Crossover">
// This class has the responsibility of bundling the application resources.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2
{
    // TODO: Get it from Nuget
    using System.Web.Optimization;

    /// <summary>
    /// Creates the bundles of static resources of the application.
    /// </summary>
    public class BundleConfig
    {
        /// <summary>
        /// Registers the application bundles.
        /// </summary>
        /// <param name="bundles">Static resource bundles.</param>
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}