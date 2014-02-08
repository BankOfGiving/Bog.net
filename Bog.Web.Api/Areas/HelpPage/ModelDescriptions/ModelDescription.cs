namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    ///     Describes a type model.
    /// </summary>
    public abstract class ModelDescription
    {
        #region Public Properties

        public string Documentation { get; set; }

        public Type ModelType { get; set; }

        public string Name { get; set; }

        #endregion
    }
}