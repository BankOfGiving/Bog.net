namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System.Collections.ObjectModel;

    public class ParameterDescription
    {
        #region Constructors and Destructors

        public ParameterDescription()
        {
            this.Annotations = new Collection<ParameterAnnotation>();
        }

        #endregion

        #region Public Properties

        public Collection<ParameterAnnotation> Annotations { get; private set; }

        public string Documentation { get; set; }

        public string Name { get; set; }

        public ModelDescription TypeDescription { get; set; }

        #endregion
    }
}