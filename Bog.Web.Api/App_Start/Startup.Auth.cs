namespace Bog.Web.Api
{
    using System;

    using Bog.Web.Api.Providers;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    using Owin;

    public partial class Startup
    {
        #region Constructors and Destructors

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

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static string PublicClientId { get; private set; }
        public static Func<UserManager<IdentityUser>> UserManagerFactory { get; set; }

        #endregion

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        #region Public Methods and Operators

        public void ConfigureAuth(IAppBuilder app)
        {
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            app.UseMicrosoftAccountAuthentication(
            clientId: "000000004C107D13",
            clientSecret: "C5EFKmId45HlG0H0X65Rqidc1h7Fcw1A");

            app.UseTwitterAuthentication(
            consumerKey: "9d61pQQu1XuCkc8Op6IqA",
            consumerSecret: "bABg2DdiTa2tL0weeS4Y4VTAux87QWPi7zEa0IqFYg");

            app.UseFacebookAuthentication(
            appId: "178224175708352",
            appSecret: "0f75d3ce541c9271abe13256fd4d6645");

            app.UseGoogleAuthentication();
        }

        #endregion
    }
}