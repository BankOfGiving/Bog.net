namespace Bog.Web.Api.Areas.HelpPage.ModelDescriptions
{
    using System;
    using System.Reflection;

    public interface IModelDocumentationProvider
    {
        #region Public Methods and Operators

        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);

        #endregion
    }
}