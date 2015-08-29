//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="Crossover">
// This class has the responsibility of starting up the application after configuring the dependency.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Service.Ldap
{
    using Ninject;
    using Ninject.Web.Common;

    /// <summary>
    /// Startup class.
    /// </summary>
    public class Global : NinjectHttpApplication
    {
        /// <summary>
        /// Override the standard kernel to configure the DI with the application.
        /// </summary>
        /// <returns>The overridden kernel.</returns>
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new WCFNinjectModule());
        }
    }
}