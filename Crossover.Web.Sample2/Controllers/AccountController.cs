//-----------------------------------------------------------------------
// <copyright file="AccountController.cs" company="Crossover">
// This controller has the responsibility of providing the security objects related to the claimed identity.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Sample2.Controllers
{
    using System.Web.Mvc;
    using Models;
    using Security;

    public class AccountController : Controller
    {
        private readonly ISecurityManager securityManager;
        public AccountController()
        {
            this.securityManager = new SecurityManager();
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if(securityManager.ValidateLogin(email: model.Email, password: model.Password))
            {
                var identity = securityManager.GetUserIdentity(email: model.Email);
                if(identity != null && identity.IsAuthenticated)
                {
                    var roles = securityManager.GetUserRoles(email: model.Email);
                    var principal = new CustomPrincipal(id: identity, rolesArray: roles);
                    HttpContext.User = principal;
                    return Redirect(returnUrl);
                }
            }
            return new HttpUnauthorizedResult();
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }
}