
// <copyright file="Startup.Auth.cs" company="">
//   
// </copyright>
// <summary>
//   The startup.
// </summary>


namespace Bog.Web.Dashboard
{
    using System;

    using Bog.Web.Dashboard.Providers;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the <see cref="Startup"/> class.
        /// </summary>
        static Startup()
        {
            PublicClientId = "self";

            UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>());

            OAuthOptions = new OAuthAuthorizationServerOptions
                               {
                                   TokenEndpointPath = new PathString("/Token"), 
                                   Provider =
                                       new ApplicationOAuthProvider(
                                       PublicClientId, 
                                       UserManagerFactory), 
                                   AuthorizeEndpointPath =
                                       new PathString("/api/Account/ExternalLogin"), 
                                   AccessTokenExpireTimeSpan = TimeSpan.FromDays(14), 
                                   AllowInsecureHttp = true
                               };
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the o auth options.
        /// </summary>
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        /// <summary>
        /// Gets the public client id.
        /// </summary>
        public static string PublicClientId { get; private set; }

        /// <summary>
        /// Gets or sets the user manager factory.
        /// </summary>
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

        #endregion

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        #region Public Methods and Operators

        /// <summary>
        /// The configure auth.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            // app.UseMicrosoftAccountAuthentication(
            // clientId: "",
            // clientSecret: "");

            // app.UseTwitterAuthentication(
            // consumerKey: "",
            // consumerSecret: "");

            // app.UseFacebookAuthentication(
            // appId: "",
            // appSecret: "");
            app.UseGoogleAuthentication();
        }

        #endregion
    }
}