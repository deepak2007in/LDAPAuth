//-----------------------------------------------------------------------
// <copyright file="LoginViewModel.cs" company="Crossover">
// This view model related to login page.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Provides the structure of the model used in the login page.
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Gets or sets the email address of the user.
        /// </summary>
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user.
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}