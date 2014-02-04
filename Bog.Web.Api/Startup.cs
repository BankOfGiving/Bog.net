using Bog.Web.Api;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Bog.Web.Api
{
    using Owin;

    public partial class Startup
    {
        #region Public Methods and Operators

        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        #endregion
    }
}