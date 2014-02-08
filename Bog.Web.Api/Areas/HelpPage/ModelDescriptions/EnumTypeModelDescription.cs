namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class EnumTypeModelDescription : ModelDescription
    {
        #region Constructors and Destructors

        public EnumTypeModelDescription()
        {
            this.Values = new Collection<EnumValueDescription>();
        }

        #endregion

        #region Public Properties

        public Collection<EnumValueDescription> Values { get; private set; }

        #endregion
    }
}