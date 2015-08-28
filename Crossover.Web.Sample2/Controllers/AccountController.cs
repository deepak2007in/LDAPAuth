//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Crossover">
// This controller has the responsibility loading the login and registration view.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2.Controllers
{
    using System.Web.Mvc;
    using System.Web.Security;
    using Models;
    using Security;
    using System.Threading.Tasks;


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
        /// </summary>
        public AccountController()
        {
            // TODO: Implement DI
            this.securityManager = new SecurityManager();
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
                if(identity != null && identity.IsAuthenticated)
                {
                    var principal = new CustomPrincipal(identity: identity, rolesArray: identity.Roles);
                    HttpContext.User = principal;
                    var cookie = FormsAuthentication.GetAuthCookie(userName: model.Email, createPersistentCookie: false);
                    Request.Cookies.Add(cookie: cookie);
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