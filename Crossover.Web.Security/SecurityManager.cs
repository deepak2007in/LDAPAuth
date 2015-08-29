//-----------------------------------------------------------------------
// <copyright file="ISecurityManager.cs" company="Crossover">
// This service has the responsibility of providing the security objects related to the claimed identity.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using global::Crossover.Web.Security.Crossover.Service.Ldap.Proxy;
    using System;
    using System.Collections;
    using System.Security.Principal;
    using System.Threading.Tasks;


    /// <summary>
    /// Provides access to the security objects and validates the claimed identity.
    /// </summary>
    public class SecurityManager : ISecurityManager
    {
        /// <summary>
        /// Holds the proxy for LDAP service component.
        /// </summary>
        private readonly ILdapService ldapServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityManager"/> class.
        /// </summary>
        public SecurityManager()
        {
            // TODO: Implement DI
            ldapServiceClient = new LdapServiceClient();
        }
        
        /// <summary>
        /// Gets the user identity associated with the logged in user.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <returns>The user identity.</returns>
        public async Task<CustomIdentity> GetUserIdentityAsync(string email)
        {
            var isAuthenticated = await this.ldapServiceClient.IsAuthenticatedAsync(email: email);
            if(isAuthenticated)
            {
                var groups = await this.ldapServiceClient.GetUserInfoAsync(email: email);
                var userRoles = string.Join("|", groups.UserGroups);
                return new CustomIdentity(email: email, roles: userRoles, isAuthenticated: isAuthenticated);
            }

            return new CustomIdentity(email: email, roles: string.Empty, isAuthenticated: isAuthenticated);
        }
        
        /// <summary>
        /// Validates the provided e-mail and password.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <param name="password">Password to validate against.</param>
        /// <returns>True if authenticated successfully; false otherwise.</returns>
        public async Task<bool> ValidateLoginAsync(string email, string password)
        {
            var userInfo = await this.ldapServiceClient.AuthenticateAsync(email: email, passwordHash: password);
            return userInfo != null;
        }
    }
}