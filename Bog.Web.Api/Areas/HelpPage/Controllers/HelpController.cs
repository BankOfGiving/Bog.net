namespace Bog.Web.Api.Areas.HelpPage.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;

    using Bog.Web.Api.Areas.HelpPage.Models;

    /// <summary>
    ///     The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        #region Constructors and Destructors

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        #endregion

        #region Public Properties

        public HttpConfiguration Configuration { get; private set; }

        #endregion

        #region Public Methods and Operators

        public ActionResult Api(string apiId)
        {
            if (!string.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = this.Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return this.View("Error");
        }

        public ActionResult Index()
        {
            this.ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();
            return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        #endregion
    }
}