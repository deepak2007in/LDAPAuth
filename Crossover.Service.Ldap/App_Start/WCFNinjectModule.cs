//-----------------------------------------------------------------------
// <copyright file="WCFNinjectModule.cs" company="Crossover">
// This service has the responsibility of injecting the dependency.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Service.Ldap
{
    using Util.Ldap;
    using Ninject.Modules;

    /// <summary>
    /// Injects the dependency.
    /// </summary>
    public class WCFNinjectModule : NinjectModule
    {
        /// <summary>
        /// Defines configuration for the dependency evaluation.
        /// </summary>
        public override void Load()
        {
            Bind<ILdapQuery>().To<LdapQuery>();
        }
    }
}