//-----------------------------------------------------------------------
// <copyright file="LdapQuery.cs" company="Crossover">
// This service has the responsibility of interacting with LDAP directory.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Util.Ldap
{
    using System;
    using System.Linq;
    using System.DirectoryServices;
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
        public string GetPasswordHash(string userToken)
        {
            var path = "LDAP://DC=Softwaremaker,DC=net";
            var directoryEntry = new DirectoryEntry(path: path);
            var rootSearch = new DirectorySearcher(directoryEntry);
            rootSearch.Filter = "(&(objectCategory=user)(userPrincipalName=" + userToken +"))";
            var searchResults = rootSearch.FindAll() as IEnumerable<SearchResult>;
            var commonName = searchResults.Select(searchResult => searchResult.Properties["cn"]).FirstOrDefault();
            return commonName.ToString();
        }

        /// <summary>
        ///  Finds and returns the user's returned groups. 
        /// </summary>
        /// <param name="commonName">The Common Name (CN).</param>
        /// <returns>Collection of user groups associated with user.</returns>
        public IList<string> GetGroups(string commonName)
        {
            var path = string.Concat("LDAP://server/CN=", commonName, ",CN=Users,DC=Softwaremaker,DC=net");
            var user = new DirectoryEntry(path: path);
            var properties = user.Properties as IEnumerable<PropertyValueCollection>;
            var userGroups = properties.Where(property => property.PropertyName == "memberOf").Select(property => property.Value.ToString());
            return userGroups.ToList();
        }

        /// <summary>
        /// Registers the new user into the LDAP directory.
        /// </summary>
        /// <param name="userToken">The lookup key.</param>
        /// <param name="passwordHash">The password hash.</param>
        /// <returns>Flag indicating the success of the result.</returns>
        public bool RegisterUser(string userToken, string passwordHash)
        {
            throw new NotImplementedException();
        }
    }
}