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
                var securityManager = new SecurityManager();
                var identity = securityManager.GetUserIdentity(authCookie.Name);
                var roles = identity.Roles;
                var principal = new CustomPrincipal(identity: identity, rolesArray: roles);
                Context.User = principal;
            }
        }
    }
}