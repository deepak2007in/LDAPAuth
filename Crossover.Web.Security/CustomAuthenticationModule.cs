//-----------------------------------------------------------------------
// <copyright file="CustomAuthenticationModule.cs" company="Crossover">
// This class has the responsibility of intercepting the web request and processing the authentication specific information.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System;
    using System.Configuration;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Security;


    /// <summary>
    /// Enables ASP.NET applications to use Custom authentication based on forms authentication. 
    /// This class cannot be inherited.
    /// </summary>
    public sealed class CustomAuthenticationModule : IHttpModule
	{
        /// <summary>
        /// Holds a static reference of utility to interact with the WCF service.
        /// </summary>
        public static readonly ISecurityManager securityManager;

        /// <summary>
        /// Initializes a static member of HTTP module.
        /// </summary>
        static CustomAuthenticationModule()
        {
            securityManager = new SecurityManager();
        }

        /// <summary>
        /// Holds the reference of the underlining HTTP Application.
        /// </summary>
		HttpApplication app = null;

        /// <summary>
        /// Configuration key for getting the login URL.
        /// </summary>
		const string LOGINURL_KEY = "CustomAuthentication.LoginUrl";

		/// <summary>
		/// Initializes the module derived from IHttpModule when called by the HttpRuntime . 
		/// </summary>
		/// <param name="httpapp">The HttpApplication module</param>
		public void Init(HttpApplication httpapp)
		{
			this.app = httpapp;
            var wrapper = new EventHandlerTaskAsyncHelper(OnAuthenticate);
            app.AddOnAuthenticateRequestAsync(wrapper.BeginEventHandler, wrapper.EndEventHandler);
		}

        /// <summary>
        /// Authentication delegate for the application.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event argument.</param>
		async Task OnAuthenticate(object sender, EventArgs e)
		{
			app = (HttpApplication)sender;
            var req = app.Request;
			var res = app.Response;

			string loginUrl = ConfigurationManager.AppSettings[LOGINURL_KEY];
			if(loginUrl == null || loginUrl.Trim() == String.Empty)
			{
				throw new Exception(" CustomAuthentication.LoginUrl entry not found in appSettings section of Web.config");
			}

			string cookieName = FormsAuthentication.FormsCookieName;

			int requestedPageIndex = req.Path.LastIndexOf("/");
			string page = req.Path.Substring(requestedPageIndex+1, (req.Path.Length - (requestedPageIndex + 1)));

			int loginPageIndex = loginUrl.LastIndexOf("/");
			string loginPage = loginUrl.Substring(loginPageIndex+1, (loginUrl.Length - (loginPageIndex + 1)));

            var isAuthenticated = false;
			if(page != null && !(page.Trim().ToUpper().Equals(loginPage.ToUpper())))
			{
				if(req.Cookies.Count > 0 && req.Cookies[cookieName.ToUpper()] != null)
				{
					HttpCookie cookie = req.Cookies[cookieName.ToUpper()];
                    if (cookie != null)
					{
                        string email = FormsAuthentication.Decrypt(cookie.Value).Name;
                        var userIdentity = await securityManager.GetUserIdentityAsync(email: email);
                        if (userIdentity.IsAuthenticated)
                        {
                            var principal = new CustomPrincipal(userIdentity, userIdentity.Roles);
                            app.Context.User = principal;
                            Thread.CurrentPrincipal = principal;
                            isAuthenticated = true;
                        }
					}
				}
                if (!isAuthenticated)
                {
                    res.Redirect(req.ApplicationPath + loginUrl + "?ReturnUrl=" + req.Path, true);
                }
            }
		}

        /// <summary>
        /// Dispose Method
        /// </summary>
		public void Dispose()
		{
		}
	}
}