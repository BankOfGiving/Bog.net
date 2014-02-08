﻿namespace Bog.Web.Api.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    ///     The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The index.
        /// </summary>
        /// <returns>
        ///     The <see cref="ActionResult" />.
        /// </returns>
        public ActionResult Index()
        {
            this.ViewBag.Title = "Home Page";

            return this.View();
        }

        #endregion
    }
}