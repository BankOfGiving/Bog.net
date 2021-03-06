﻿using Bog.Web.Dashboard;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Bog.Web.Dashboard
{
    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        #region Public Methods and Operators

        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }

        #endregion
    }
}