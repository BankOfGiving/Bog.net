namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ComplexTypeModelDescription : ModelDescription
    {
        #region Constructors and Destructors

        public ComplexTypeModelDescription()
        {
            this.Properties = new Collection<ParameterDescription>();
        }

        #endregion

        #region Public Properties

        public Collection<ParameterDescription> Properties { get; private set; }

        #endregion
    }
}