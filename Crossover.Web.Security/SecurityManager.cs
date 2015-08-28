﻿//-----------------------------------------------------------------------
// <copyright file="ISecurityManager.cs" company="Crossover">
// This service has the responsibility of providing the security objects related to the claimed identity.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System;
    using System.Collections;
    using System.Security.Principal;

    /// <summary>
    /// Provides access to the security objects and validates the claimed identity.
    /// </summary>
    public class SecurityManager : ISecurityManager
    {
        /// <summary>
        /// Gets the user identity associated with the logged in user.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <returns>The user identity.</returns>
        public CustomIdentity GetUserIdentity(string email)
        {
            return new CustomIdentity(email: email, roles: "Programmer|TechLead|Manager", isAuthenticated: true);
        }
        
        /// <summary>
        /// Validates the provided e-mail and password.
        /// </summary>
        /// <param name="email">The unique identifier of the user.</param>
        /// <param name="password">Password to validate against.</param>
        /// <returns>True if authenticated successfully; false otherwise.</returns>
        public bool ValidateLogin(string email, string password)
        {
            return true;
        }
    }
}