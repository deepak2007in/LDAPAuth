//-----------------------------------------------------------------------
// <copyright file="CustomPrincipal.cs" company="Crossover">
// This class has the responsibility for providing roles and identity specific information of the logged in user.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System;
    using System.Collections;
    using System.Security.Principal;

    /// <summary>
    /// Represents the Custom Principal.
    /// </summary>
    [Serializable]
	public class CustomPrincipal: IPrincipal
	{
		/// <summary>
        /// Holds the identity of the user.
        /// </summary>
		private readonly IIdentity identity;
        /// <summary>
        /// Holds the collection of roles associated with user.
        /// </summary>
		private readonly ArrayList roles;
        
		/// <summary>
		/// Initializes a new instance of the GenericPrincipal class 
		/// from a CustomIdentity and an ArrayList of role names 
		/// to which the user represented by that CustomIdentity belongs
		/// </summary>
		/// <param name="identity">Identity of the user.</param>
		/// <param name="rolesArray">Collection of roles associated with the user.</param>
		public CustomPrincipal(IIdentity identity, ArrayList rolesArray)
		{
			this.identity = identity;
			roles = rolesArray;
		}
		
		/// <summary>
		/// Determines whether the current CustomPrincipal belongs to the specified role.
		/// </summary>
		/// <param name="role">The name of the role for which to check membership</param>
		/// <returns>true if the current CustomPrincipal is a member of the specified role; 
		/// otherwise, false.</returns>
		public bool IsInRole(string role)
		{
			return roles.Contains( role );
		}

		/// <summary>
		/// Gets the CustomIdentity of the user represented by the current CustomPrincipal.
		/// </summary>
		public IIdentity Identity { get; private set; }
	}
}