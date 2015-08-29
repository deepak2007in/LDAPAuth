//-----------------------------------------------------------------------
// <copyright file="LdapService.cs" company="Crossover">
// This service has the responsibility of serving the single-sign on authentication and authorization with LDAP
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Service.Ldap
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using Util.Ldap;

    /// <summary>
    /// Service implementation for single-sign on authentication and authorization.
    /// </summary>
    public class LdapService : ILdapService
    {
        /// <summary>
        /// Holds the static collection of authenticated users along with their group information.
        /// </summary>
        private static readonly IDictionary<string, UserInfo> authenticatedUsers;
        
        /// <summary>
        /// Holds the utility for querying the LDAP directory
        /// </summary>
        private readonly ILdapQuery ldapQuery;

        /// <summary>
        /// Initializes a static member variables of the <see cref="LdapService"/> class.
        /// </summary>
        static LdapService()
        {
            authenticatedUsers = new ConcurrentDictionary<string, UserInfo>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LdapService"/> class with the required dependency.
        /// </summary>
        /// <param name="ldapQuery">Utility for querying the LDAP directory.</param>
        public LdapService(ILdapQuery ldapQuery)
        {
            this.ldapQuery = ldapQuery;
        }

        /// <summary>
        /// Validate the password hash for user and authenticate him.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <param name="password">Hash value for user password.</param>
        /// <returns>The collection of user groups.</returns>
        public UserInfo Authenticate(string loginName, string password)
        {
            if(!this.IsAuthenticated(loginName: loginName))
            {
                var passwordInLdap = this.ldapQuery.GetPassword(userToken: loginName);
                if (password == passwordInLdap)
                {
                    var groups = this.ldapQuery.GetGroups(commonName: loginName);
                    var userInfo = new UserInfo { UserGroups = groups };
                    return userInfo;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return this.GetUserInfo(loginName: loginName);
            }
        }

        /// <summary>
        /// Gets the user group information if the user is authenticated.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        public UserInfo GetUserInfo(string loginName)
        {
            if(this.IsAuthenticated(loginName: loginName))
            {
                return authenticatedUsers[key: loginName];
            }
            return null;
        }

        /// <summary>
        /// Validate whether the user is already authenticated or not.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        public bool IsAuthenticated(string loginName)
        {
            return authenticatedUsers.ContainsKey(loginName);
        }
    }
}