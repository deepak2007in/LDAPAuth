//-----------------------------------------------------------------------
// <copyright file="UnityWebActivator.cs" company="Crossover">
// This class has the responsibility of integrating the unity mapping into the application.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Crossover.Web.MvcSample.UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(Crossover.Web.MvcSample.UnityWebActivator), "Shutdown")]
namespace Crossover.Web.MvcSample
{
    using System.Linq;
    using System.Web.Mvc;
    using Microsoft.Practices.Unity.Mvc;

    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
            var container = UnityConfig.GetConfiguredContainer();

            FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// Disposes the Unity container when the application is shut down.
        /// </summary>
        public static void Shutdown()
        {
            var container = UnityConfig.GetConfiguredContainer();
            container.Dispose();
        }
    }
}