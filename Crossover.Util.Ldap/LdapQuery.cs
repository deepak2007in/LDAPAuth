//-----------------------------------------------------------------------
// <copyright file="LdapQuery.cs" company="Crossover">
// This service has the responsibility of interacting with LDAP directory.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Util.Ldap
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implementation for interacting with the LDAP directory
    /// </summary>
    public class LdapQuery : ILdapQuery
    {
        /// <summary>
        /// Gets the Common Name (CN) of the Login information of the LDAP Directory.
        /// </summary>
        /// <remarks>The CN is an unique identity and cannot be changed or edited in LDAP.</remarks>
        /// <param name="userToken">The lookup key.</param>
        /// <returns>The Common Name (CN) string.</returns>
        public string GetCommonName(string userToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Finds and returns the user's returned groups. 
        /// </summary>
        /// <param name="commonName">The Common Name (CN).</param>
        /// <returns>Collection of user groups associated with user.</returns>
        public IList<string> GetGroups(string commonName)
        {
            throw new NotImplementedException();
        }
    }
}