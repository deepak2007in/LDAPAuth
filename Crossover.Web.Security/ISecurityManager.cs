//-----------------------------------------------------------------------
// <copyright file="ISecurityManager.cs" company="Crossover">
// This contract has the responsibility of providing the security objects related to the claimed identity.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System.Collections;
    using System.Security.Principal;

    /// <summary>
    /// Contract for providing access to the security objects and validates the claimed identity.
    /// </summary>
    public interface ISecurityManager
    {
        /// <summary>
        /// Gets the user identity associated with the logged in user.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <returns>The user identity.</returns>
        CustomIdentity GetUserIdentity(string email);
        
        /// <summary>
        /// Validates the provided e-mail and password.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <param name="password">Password to validate against.</param>
        /// <returns>True if authenticated successfully; false otherwise.</returns>
        bool ValidateLogin(string email, string password);
    }
}