namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    public class KeyValuePairModelDescription : ModelDescription
    {
        #region Public Properties

        public ModelDescription KeyModelDescription { get; set; }

        public ModelDescription ValueModelDescription { get; set; }

        #endregion
    }
}