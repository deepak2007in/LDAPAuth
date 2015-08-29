//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Crossover">
// This controller has the responsibility loading the login and registration view.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Models;
    using Security;
    using System.Web.Security;
    using System;
    using System.Web;




    /// <summary>
    /// Loads the login and registration view.
    /// </summary>
    public class AccountController : Controller
    {
        /// <summary>
        /// Holds the service utility for performing the authentication with the LDAP WCF service.
        /// </summary>
        private readonly ISecurityManager securityManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class with the required dependency.
        /// <param name="securityManager">The service utility for performing the authentication with the LDAP WCF service.</param>
        /// </summary>
        public AccountController(ISecurityManager securityManager)
        {
            this.securityManager = securityManager;
        }

        /// <summary>
        /// Renders the login view with the URL to redirect after login.
        /// </summary>
        /// <param name="returnUrl">The URL to redirect.</param>
        /// <returns>Loads the view.</returns>
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        /// <summary>
        /// Post the username and password for authentication.
        /// </summary>
        /// <param name="model">The username and password.</param>
        /// <param name="returnUrl">The URL to redirect.</param>
        /// <returns>Performs the authentication.</returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(await securityManager.ValidateLoginAsync(email: model.Email, password: model.Password))
            {
                var identity = await securityManager.GetUserIdentityAsync(email: model.Email);
                var cookieIssueDate = DateTime.Now;
                if(identity != null && identity.IsAuthenticated)
                {
                    var ticket = new FormsAuthenticationTicket(
                        version: 0,
                        name: model.Email,
                        issueDate: cookieIssueDate,
                        expiration: cookieIssueDate.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                        isPersistent: false,
                        userData: identity.UserRoles);

                    string encryptedContent = FormsAuthentication.Encrypt(ticket: ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedContent)
                    {
                        Domain = FormsAuthentication.CookieDomain,
                        Path = FormsAuthentication.FormsCookiePath,
                        HttpOnly = true
                    };

                    Response.Cookies.Add(cookie: cookie);
                    var principal = new CustomPrincipal(identity: identity, rolesArray: identity.Roles);
                    HttpContext.User = principal;
                    returnUrl = returnUrl ?? "/";
                    return Redirect(returnUrl);
                }
            }
            return new HttpUnauthorizedResult();
        }

        /// <summary>
        /// Renders the registration view.
        /// </summary>
        /// <returns>The registration view.</returns>
        [AllowAnonymous]
        public ViewResult Register()
        {
            return View();
        }
    }
}