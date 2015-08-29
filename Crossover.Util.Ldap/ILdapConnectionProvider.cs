//-----------------------------------------------------------------------
// <copyright file="ILdapConnectionProvider.cs" company="Crossover">
// This contract has the responsibility of providing LDAP connection information.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Util.Ldap
{
    /// <summary>
    /// Contract for providing the LDAP connection info.
    /// </summary>
    public interface ILdapConnectionProvider
    {
        /// <summary>
        /// Gets the LDAP server.
        /// </summary>
        string LDAPServer { get; }
        /// <summary>
        /// Gets the distinguished name.
        /// </summary>
        string DistinguishedName { get; }
        /// <summary>
        /// Gets the user name to connect LDAP.
        /// </summary>
        string UserName { get; }
        /// <summary>
        /// Gets the password to connect LDAP.
        /// </summary>
        string Password { get; }
    }
}