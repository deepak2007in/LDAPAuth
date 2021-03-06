﻿//-----------------------------------------------------------------------
// <copyright file="ISecurityManager.cs" company="Crossover">
// This contract has the responsibility of providing the security objects related to the claimed identity.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System.Threading.Tasks;

    /// <summary>
    /// Contract for providing access to the security objects and validates the claimed identity.
    /// </summary>
    public interface ISecurityManager
    {
        /// <summary>
        /// Asynchronously gets the user identity associated with the logged in user.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <returns>The user identity.</returns>
        Task<CustomIdentity> GetUserIdentityAsync(string email);

        /// <summary>
        /// Validates the provided e-mail and password.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <param name="password">Password to validate against.</param>
        /// <returns>True if authenticated successfully; false otherwise.</returns>
        Task<bool> ValidateLoginAsync(string email, string password);
    }
}