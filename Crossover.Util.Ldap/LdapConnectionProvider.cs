//-----------------------------------------------------------------------
// <copyright file="LdapConnectionProvider.cs" company="Crossover">
// This implementation has the responsibility of providing LDAP connection information.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Util.Ldap
{
    using System.Configuration;

    /// <summary>
    /// Structure for providing the LDAP connection info.
    /// </summary>
    public class LdapConnectionProvider : ILdapConnectionProvider
    {
        /// <summary>
        /// Gets the LDAP server.
        /// </summary>
        public string LDAPServer
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAP.Connection.Server"];
            }
        }

        /// <summary>
        /// Gets the distinguished name.
        /// </summary>
        public string DistinguishedName
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAP.Connection.DistinguishedName"];
            }
        }

        /// <summary>
        /// Gets the user name to connect LDAP.
        /// </summary>
        public string UserName
        {
            get
            {
                return this.DistinguishedName;
            }
        }

        /// <summary>
        /// Gets the password to connect LDAP.
        /// </summary>
        public string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["LDAP.Connection.Password"];
            }
        }
    }
}