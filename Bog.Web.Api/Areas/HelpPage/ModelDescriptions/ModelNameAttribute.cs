namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System;

    /// <summary>
    ///     Use this attribute to change the name of the <see cref="ModelDescription" /> generated for a type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum, AllowMultiple = false, 
        Inherited = false)]
    public sealed class ModelNameAttribute : Attribute
    {
        #region Constructors and Destructors

        public ModelNameAttribute(string name)
        {
            this.Name = name;
        }

        #endregion

        #region Public Properties

        public string Name { get; private set; }

        #endregion
    }
}