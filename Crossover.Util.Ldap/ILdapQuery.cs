//-----------------------------------------------------------------------
// <copyright file="LdapQuery.cs" company="Crossover">
// This contract has the responsibility of interacting with LDAP directory.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Util.Ldap
{
    using System.Collections.Generic;

    /// <summary>
    /// Contract for interacting with the LDAP directory
    /// </summary>
    public interface ILdapQuery
    {
        /// <summary>
        /// Gets the Common Name (CN) of the Login information of the LDAP Directory.
        /// </summary>
        /// <remarks>The CN is an unique identity and cannot be changed or edited in LDAP.</remarks>
        /// <param name="userToken">The lookup key.</param>
        /// <returns>The Common Name (CN) string.</returns>
        string GetCommonName(string userToken);

        /// <summary>
        ///  Finds and returns the user's returned groups. 
        /// </summary>
        /// <param name="commonName">The Common Name (CN).</param>
        /// <returns>Collection of user groups associated with user.</returns>
        IList<string> GetGroups(string commonName);

        /// <summary>
        /// Registers the new user into the LDAP directory.
        /// </summary>
        /// <param name="userToken">The lookup key.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns>Flag indicating the success of the result.</returns>
        bool RegisterUser(string userToken, string passwordHash);
    }
}