//-----------------------------------------------------------------------
// <copyright file="CustomIdentity.cs" company="Crossover">
// This class has the responsibility of holding current user metadata along with his authentication status.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System;
    using System.Collections;
    using System.Security.Principal;

    /// <summary>
    /// Represents the Identity of a User. 
    /// Stores the details of a User. 
    /// Implements the IIDentity interface.
    /// </summary>
    [Serializable]
	public class CustomIdentity : IIdentity
	{
		/// <summary>
		/// The default constructor initializes any fields to their default values.
		/// </summary>
		public CustomIdentity()
		{
			this.UserEmail = String.Empty;
			this.UserRoles = String.Empty;
		}

		/// <summary>
		/// Initializes a new instance of the CustomIdentity class 
		/// with the passed parameters
		/// </summary>
		/// <param name="email">Email of the User</param>
        /// <param name="roles">Roles associated with the user.</param>
		public CustomIdentity(string email, string roles, bool isAuthenticated)
		{
			this.UserEmail = email;
			this.UserRoles = roles;
            this.IsAuthenticated = isAuthenticated;
		}

		// Properties
		/// <summary>
		/// Gets the Authentication Type
		/// </summary>
		public string AuthenticationType 
		{
			get { return "Custom"; }
		}

		/// <summary>
		/// Indicates whether the User is authenticated
		/// </summary>
		public bool IsAuthenticated { get; set; }

		/// <summary>
		/// Gets or sets the UserID of the User
		/// </summary>
		public string Name
        {
            get
            {
                return this.UserEmail;
            }
            set
            {
                this.UserEmail = value;
            }
        }
        
		/// <summary>
		/// Gets or sets the Email of the User
		/// </summary>
		public string UserEmail { get; set; }

		/// <summary>
		/// Gets or sets the Roles of the User
		/// The roles are stored in a pipe "|" separated string
		/// </summary>
		public string UserRoles { get; set; }

        public ArrayList Roles
        {
            get
            {
                string[] roles = this.UserRoles.Split(new char[] { '|' });
                ArrayList arrRoles = new ArrayList();
                arrRoles.InsertRange(0, roles);
                return arrRoles;
            }
        }
	}
}