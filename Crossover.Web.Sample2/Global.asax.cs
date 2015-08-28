using Crossover.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Crossover.Web.Sample2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if(authCookie != null)
            {
                var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                var securityManager = new SecurityManager();
                var identity = securityManager.GetUserIdentity(authCookie.Name);
                var roles = securityManager.GetUserRoles(authCookie.Name);
                var principal = new CustomPrincipal(id: identity, rolesArray: roles);
                Context.User = principal;
            }
        }
    }
}