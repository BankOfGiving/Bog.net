﻿namespace Bog.Web.Dashboard.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Security.Cryptography;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Http;

    using Bog.Web.Dashboard.Models;
    using Bog.Web.Dashboard.Providers;
    using Bog.Web.Dashboard.Results;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OAuth;

    /// <summary>
    /// The account controller.
    /// </summary>
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        #region Constants

        /// <summary>
        /// The local login provider.
        /// </summary>
        private const string LocalLoginProvider = "Local";

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        public AccountController()
            : this(Startup.UserManagerFactory(), Startup.OAuthOptions.AccessTokenFormat)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountController"/> class.
        /// </summary>
        /// <param name="userManager">
        /// The user manager.
        /// </param>
        /// <param name="accessTokenFormat">
        /// The access token format.
        /// </param>
        public AccountController(
            UserManager<IdentityUser> userManager, 
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            this.UserManager = userManager;
            this.AccessTokenFormat = accessTokenFormat;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the access token format.
        /// </summary>
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        /// <summary>
        /// Gets the user manager.
        /// </summary>
        public UserManager<IdentityUser> UserManager { get; private set; }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the authentication.
        /// </summary>
        private IAuthenticationManager Authentication
        {
            get
            {
                return this.Request.GetOwinContext().Authentication;
            }
        }

        #endregion

        // GET api/Account/UserInfo

        // POST api/Account/AddExternalLogin
        #region Public Methods and Operators

        /// <summary>
        /// The add external login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("AddExternalLogin")]
        public async Task<IHttpActionResult> AddExternalLogin(AddExternalLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            AuthenticationTicket ticket = this.AccessTokenFormat.Unprotect(model.ExternalAccessToken);

            if (ticket == null || ticket.Identity == null
                || (ticket.Properties != null && ticket.Properties.ExpiresUtc.HasValue
                    && ticket.Properties.ExpiresUtc.Value < DateTimeOffset.UtcNow))
            {
                return this.BadRequest("External login failure.");
            }

            ExternalLoginData externalData = ExternalLoginData.FromIdentity(ticket.Identity);

            if (externalData == null)
            {
                return this.BadRequest("The external login is already associated with an account.");
            }

            IdentityResult result =
                await
                this.UserManager.AddLoginAsync(
                    this.User.Identity.GetUserId(), 
                    new UserLoginInfo(externalData.LoginProvider, externalData.ProviderKey));

            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        /// The change password.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("ChangePassword")]
        public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult result =
                await
                this.UserManager.ChangePasswordAsync(
                    this.User.Identity.GetUserId(), 
                    model.OldPassword, 
                    model.NewPassword);
            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        // POST api/Account/RemoveLogin

        // GET api/Account/ExternalLogin
        /// <summary>
        /// The get external login.
        /// </summary>
        /// <param name="provider">
        /// The provider.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalCookie)]
        [AllowAnonymous]
        [Route("ExternalLogin", Name = "ExternalLogin")]
        public async Task<IHttpActionResult> GetExternalLogin(string provider, string error = null)
        {
            if (error != null)
            {
                return this.Redirect(this.Url.Content("~/") + "#error=" + Uri.EscapeDataString(error));
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return new ChallengeResult(provider, this);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return this.InternalServerError();
            }

            if (externalLogin.LoginProvider != provider)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                return new ChallengeResult(provider, this);
            }

            IdentityUser user =
                await
                this.UserManager.FindAsync(new UserLoginInfo(externalLogin.LoginProvider, externalLogin.ProviderKey));

            bool hasRegistered = user != null;

            if (hasRegistered)
            {
                this.Authentication.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                ClaimsIdentity oAuthIdentity =
                    await this.UserManager.CreateIdentityAsync(user, OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity =
                    await this.UserManager.CreateIdentityAsync(user, CookieAuthenticationDefaults.AuthenticationType);
                AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
                this.Authentication.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                var identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                this.Authentication.SignIn(identity);
            }

            return this.Ok();
        }

        // GET api/Account/ExternalLogins?returnUrl=%2F&generateState=true
        /// <summary>
        /// The get external logins.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <param name="generateState">
        /// The generate state.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        [AllowAnonymous]
        [Route("ExternalLogins")]
        public IEnumerable<ExternalLoginViewModel> GetExternalLogins(string returnUrl, bool generateState = false)
        {
            IEnumerable<AuthenticationDescription> descriptions = this.Authentication.GetExternalAuthenticationTypes();
            var logins = new List<ExternalLoginViewModel>();

            string state;

            if (generateState)
            {
                const int strengthInBits = 256;
                state = RandomOAuthStateGenerator.Generate(strengthInBits);
            }
            else
            {
                state = null;
            }

            foreach (AuthenticationDescription description in descriptions)
            {
                var login = new ExternalLoginViewModel
                                {
                                    Name = description.Caption, 
                                    Url =
                                        this.Url.Route(
                                            "ExternalLogin", 
                                            new
                                                {
                                                    provider = description.AuthenticationType, 
                                                    response_type = "token", 
                                                    client_id = Startup.PublicClientId, 
                                                    redirect_uri =
                                        new Uri(this.Request.RequestUri, returnUrl).AbsoluteUri, 
                                                    state
                                                }), 
                                    State = state
                                };
                logins.Add(login);
            }

            return logins;
        }

        /// <summary>
        /// The get manage info.
        /// </summary>
        /// <param name="returnUrl">
        /// The return url.
        /// </param>
        /// <param name="generateState">
        /// The generate state.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("ManageInfo")]
        public async Task<ManageInfoViewModel> GetManageInfo(string returnUrl, bool generateState = false)
        {
            IdentityUser user = await this.UserManager.FindByIdAsync(this.User.Identity.GetUserId());

            if (user == null)
            {
                return null;
            }

            var logins = new List<UserLoginInfoViewModel>();

            foreach (IdentityUserLogin linkedAccount in user.Logins)
            {
                logins.Add(
                    new UserLoginInfoViewModel
                        {
                            LoginProvider = linkedAccount.LoginProvider, 
                            ProviderKey = linkedAccount.ProviderKey
                        });
            }

            if (user.PasswordHash != null)
            {
                logins.Add(
                    new UserLoginInfoViewModel { LoginProvider = LocalLoginProvider, ProviderKey = user.UserName, });
            }

            return new ManageInfoViewModel
                       {
                           LocalLoginProvider = LocalLoginProvider, 
                           UserName = user.UserName, 
                           Logins = logins, 
                           ExternalLoginProviders = this.GetExternalLogins(returnUrl, generateState)
                       };
        }

        /// <summary>
        /// The get user info.
        /// </summary>
        /// <returns>
        /// The <see cref="UserInfoViewModel"/>.
        /// </returns>
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("UserInfo")]
        public UserInfoViewModel GetUserInfo()
        {
            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            return new UserInfoViewModel
                       {
                           UserName = this.User.Identity.GetUserName(), 
                           HasRegistered = externalLogin == null, 
                           LoginProvider = externalLogin != null ? externalLogin.LoginProvider : null
                       };
        }

        // POST api/Account/Logout
        /// <summary>
        /// The logout.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            this.Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return this.Ok();
        }

        // POST api/Account/Register
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var user = new IdentityUser { UserName = model.UserName };

            IdentityResult result = await this.UserManager.CreateAsync(user, model.Password);
            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        // POST api/Account/RegisterExternal
        /// <summary>
        /// The register external.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [OverrideAuthentication]
        [HostAuthentication(DefaultAuthenticationTypes.ExternalBearer)]
        [Route("RegisterExternal")]
        public async Task<IHttpActionResult> RegisterExternal(RegisterExternalBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            ExternalLoginData externalLogin = ExternalLoginData.FromIdentity(this.User.Identity as ClaimsIdentity);

            if (externalLogin == null)
            {
                return this.InternalServerError();
            }

            var user = new IdentityUser { UserName = model.UserName };
            user.Logins.Add(
                new IdentityUserLogin
                    {
                        LoginProvider = externalLogin.LoginProvider, 
                        ProviderKey = externalLogin.ProviderKey
                    });
            IdentityResult result = await this.UserManager.CreateAsync(user);
            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        /// The remove login.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("RemoveLogin")]
        public async Task<IHttpActionResult> RemoveLogin(RemoveLoginBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult result;

            if (model.LoginProvider == LocalLoginProvider)
            {
                result = await this.UserManager.RemovePasswordAsync(this.User.Identity.GetUserId());
            }
            else
            {
                result =
                    await
                    this.UserManager.RemoveLoginAsync(
                        this.User.Identity.GetUserId(), 
                        new UserLoginInfo(model.LoginProvider, model.ProviderKey));
            }

            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        /// <summary>
        /// The set password.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Route("SetPassword")]
        public async Task<IHttpActionResult> SetPassword(SetPasswordBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            IdentityResult result =
                await this.UserManager.AddPasswordAsync(this.User.Identity.GetUserId(), model.NewPassword);
            IHttpActionResult errorResult = this.GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return this.Ok();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.UserManager.Dispose();
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// The get error result.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        this.ModelState.AddModelError(string.Empty, error);
                    }
                }

                if (this.ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return this.BadRequest();
                }

                return this.BadRequest(this.ModelState);
            }

            return null;
        }

        #endregion

        /// <summary>
        /// The random o auth state generator.
        /// </summary>
        private static class RandomOAuthStateGenerator
        {
            #region Static Fields

            /// <summary>
            /// The _random.
            /// </summary>
            private static readonly RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The generate.
            /// </summary>
            /// <param name="strengthInBits">
            /// The strength in bits.
            /// </param>
            /// <returns>
            /// The <see cref="string"/>.
            /// </returns>
            /// <exception cref="ArgumentException">
            /// </exception>
            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                var data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }

            #endregion
        }

        /// <summary>
        /// The external login data.
        /// </summary>
        private class ExternalLoginData
        {
            #region Public Properties

            /// <summary>
            /// Gets or sets the login provider.
            /// </summary>
            public string LoginProvider { get; set; }

            /// <summary>
            /// Gets or sets the provider key.
            /// </summary>
            public string ProviderKey { get; set; }

            /// <summary>
            /// Gets or sets the user name.
            /// </summary>
            public string UserName { get; set; }

            #endregion

            #region Public Methods and Operators

            /// <summary>
            /// The from identity.
            /// </summary>
            /// <param name="identity">
            /// The identity.
            /// </param>
            /// <returns>
            /// The <see cref="ExternalLoginData"/>.
            /// </returns>
            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || string.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || string.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                           {
                               LoginProvider = providerKeyClaim.Issuer, 
                               ProviderKey = providerKeyClaim.Value, 
                               UserName = identity.FindFirstValue(ClaimTypes.Name)
                           };
            }

            /// <summary>
            /// The get claims.
            /// </summary>
            /// <returns>
            /// The <see cref="IList"/>.
            /// </returns>
            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, this.ProviderKey, null, this.LoginProvider));

                if (this.UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, this.UserName, null, this.LoginProvider));
                }

                return claims;
            }

            #endregion
        }
    }
}