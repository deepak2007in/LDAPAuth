//-----------------------------------------------------------------------
// <copyright file="ILdapService.cs" company="Crossover">
// This contract has the responsibility of serving the single-sign on authentication and authorization with LDAP
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Service.Ldap
{
    using System.ServiceModel;

    /// <summary>
    /// Service contract for single-sign on authentication and authorization.
    /// </summary>
    [ServiceContract]
    public interface ILdapService
    {
        /// <summary>
        /// Validate the password hash for user and authenticate him.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <param name="passwordHash">Hash value for user password.</param>
        /// <returns>The collection of user groups.</returns>
        [OperationContract]
        UserInfo Authenticate(string email, string passwordHash);

        /// <summary>
        /// Gets the user group information if the user is authenticated.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        [OperationContract]
        UserInfo GetUserInfo(string email);

        /// <summary>
        /// Validate whether the user is already authenticated or not.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <returns>The collection of user groups.</returns>
        [OperationContract]
        bool IsAuthenticated(string email);

        /// <summary>
        /// Registers the user into the LDAP with his username and password.
        /// </summary>
        /// <param name="email">Login name for the user.</param>
        /// <param name="passwordHash">Hash value for user password.</param>
        /// <returns>The collection of user groups.</returns>
        [OperationContract]
        UserInfo Register(string email, string passwordHash);
    }   
}