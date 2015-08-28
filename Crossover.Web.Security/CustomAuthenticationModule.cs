//-----------------------------------------------------------------------
// <copyright file="CustomAuthenticationModule.cs" company="Crossover">
// This class has the responsibility of intercepting the web request and processing the authentication specific information.
// </copyright>
// <author>Deepak Agnihotri</author>
//-----------------------------------------------------------------------
namespace Crossover.Web.Security
{
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Threading;
    using System.Web;

    /// <summary>
    /// Enables ASP.NET applications to use Custom authentication based on forms authentication. 
    /// This class cannot be inherited.
    /// </summary>
    public sealed class CustomAuthenticationModule : IHttpModule
	{
        /// <summary>
        /// Holds the reference of the underlining HTTP Application.
        /// </summary>
		HttpApplication app = null;

        /// <summary>
        /// Configuration key for getting the login URL.
        /// </summary>
		const string LOGINURL_KEY = "CustomAuthentication.LoginUrl";

        /// <summary>
        /// Configuration key for getting the authentication cookie name.
        /// </summary>
		const string AUTHENTICATION_COOKIE_KEY = "CustomAuthentication.Cookie.Name";

		/// <summary>
		/// Initializes the module derived from IHttpModule when called by the HttpRuntime . 
		/// </summary>
		/// <param name="httpapp">The HttpApplication module</param>
		public void Init(HttpApplication httpapp)
		{
			this.app = httpapp;
			app.AuthenticateRequest += new EventHandler(this.OnAuthenticate);
		}

        /// <summary>
        /// Authentication delegate for the application.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event argument.</param>
		void OnAuthenticate(object sender, EventArgs e)
		{
			app = (HttpApplication)sender;
			HttpRequest req = app.Request;
			HttpResponse res = app.Response;

			string loginUrl = ConfigurationManager.AppSettings[LOGINURL_KEY];
			if(loginUrl == null || loginUrl.Trim() == String.Empty)
			{
				throw new Exception(" CustomAuthentication.LoginUrl entry not found in appSettings section of Web.config");
			}

			string cookieName = ConfigurationManager.AppSettings[AUTHENTICATION_COOKIE_KEY];
			if(cookieName == null || cookieName.Trim() == String.Empty)
			{
				throw new Exception(" CustomAuthentication.Cookie.Name entry not found in appSettings section section of Web.config");
			}

			int i = req.Path.LastIndexOf("/");
			string page = req.Path.Substring(i+1, (req.Path.Length - (i + 1)));

			int j = loginUrl.LastIndexOf("/");
			string loginPage = loginUrl.Substring(j+1, (loginUrl.Length - (j + 1)));

			if(page != null && !(page.Trim().ToUpper().Equals(loginPage.ToUpper())))
			{
				if(req.Cookies.Count > 0 && req.Cookies[cookieName.ToUpper()] != null)
				{
					HttpCookie cookie = req.Cookies[cookieName.ToUpper()];
					if(cookie != null)
					{
						string str = cookie.Value;
						CustomIdentity userIdentity = CustomAuthentication.Decrypt(str);
						string[] roles = userIdentity.UserRoles.Split(new char[]{'|'});
						ArrayList arrRoles = new ArrayList();
						arrRoles.InsertRange(0, roles);
						CustomPrincipal principal = new CustomPrincipal(userIdentity, arrRoles);
						app.Context.User = principal;
						Thread.CurrentPrincipal = principal;
					}
				}
				else
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