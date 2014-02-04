namespace Bog.Web.Api.Areas.HelpPage
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class HelpPageAreaRegistration : AreaRegistration
    {
        #region Public Properties

        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        #endregion

        #region Public Methods and Operators

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HelpPage_Default", 
                "Help/{action}/{apiId}", 
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }

        #endregion
    }
}