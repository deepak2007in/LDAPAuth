//-----------------------------------------------------------------------
// <copyright file="LdapService.cs" company="Crossover">
// This service has the responsibility of serving the single-sign on authentication and authorization with LDAP
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Service.Ldap
{
    using System;

    /// <summary>
    /// Service implementation for single-sign on authentication and authorization.
    /// </summary>
    public class LdapService : ILdapService
    {
        /// <summary>
        /// Validate the password hash for user and authenticate him.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <param name="passwordHash">Hash value for user password.</param>
        /// <returns>The collection of user groups.</returns>
        public UserInfo Authenticate(string loginName, string passwordHash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the user group information if the user is authenticated.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        public UserInfo GetUserInfo(string loginName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Validate whether the user is already authenticated or not.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        public bool IsAuthenticated(string loginName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Registers the user into the LDAP with his username and password.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <param name="passwordHash">Hash value for user password.</param>
        /// <returns>The collection of user groups.</returns>
        public UserInfo Register(string loginName, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}