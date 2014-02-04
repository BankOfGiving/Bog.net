namespace Bog.Web.Dashboard.Areas.HelpPage
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Http.Controllers;
    using System.Web.Http.Description;
    using System.Xml.XPath;

    /// <summary>
    ///     A custom <see cref="IDocumentationProvider" /> that reads the API documentation from an XML documentation file.
    /// </summary>
    public class XmlDocumentationProvider : IDocumentationProvider
    {
        #region Constants

        /// <summary>
        /// The method expression.
        /// </summary>
        private const string MethodExpression = "/doc/members/member[@name='M:{0}']";

        /// <summary>
        /// The parameter expression.
        /// </summary>
        private const string ParameterExpression = "param[@name='{0}']";

        /// <summary>
        /// The type expression.
        /// </summary>
        private const string TypeExpression = "/doc/members/member[@name='T:{0}']";

        #endregion

        #region Fields

        /// <summary>
        /// The _document navigator.
        /// </summary>
        private readonly XPathNavigator _documentNavigator;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XmlDocumentationProvider"/> class.
        /// </summary>
        /// <param name="documentPath">
        /// The physical path to XML document.
        /// </param>
        public XmlDocumentationProvider(string documentPath)
        {
            if (documentPath == null)
            {
                throw new ArgumentNullException("documentPath");
            }

            var xpath = new XPathDocument(documentPath);
            this._documentNavigator = xpath.CreateNavigator();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="controllerDescriptor">
        /// The controller descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetDocumentation(HttpControllerDescriptor controllerDescriptor)
        {
            XPathNavigator typeNode = this.GetTypeNode(controllerDescriptor);
            return GetTagValue(typeNode, "summary");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetDocumentation(HttpActionDescriptor actionDescriptor)
        {
            XPathNavigator methodNode = this.GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "summary");
        }

        /// <summary>
        /// The get documentation.
        /// </summary>
        /// <param name="parameterDescriptor">
        /// The parameter descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public virtual string GetDocumentation(HttpParameterDescriptor parameterDescriptor)
        {
            var reflectedParameterDescriptor = parameterDescriptor as ReflectedHttpParameterDescriptor;
            if (reflectedParameterDescriptor != null)
            {
                XPathNavigator methodNode = this.GetMethodNode(reflectedParameterDescriptor.ActionDescriptor);
                if (methodNode != null)
                {
                    string parameterName = reflectedParameterDescriptor.ParameterInfo.Name;
                    XPathNavigator parameterNode =
                        methodNode.SelectSingleNode(
                            string.Format(CultureInfo.InvariantCulture, ParameterExpression, parameterName));
                    if (parameterNode != null)
                    {
                        return parameterNode.Value.Trim();
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// The get response documentation.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetResponseDocumentation(HttpActionDescriptor actionDescriptor)
        {
            XPathNavigator methodNode = this.GetMethodNode(actionDescriptor);
            return GetTagValue(methodNode, "returns");
        }

        #endregion

        #region Methods

        /// <summary>
        /// The get member name.
        /// </summary>
        /// <param name="method">
        /// The method.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetMemberName(MethodInfo method)
        {
            string name = string.Format(
                CultureInfo.InvariantCulture, 
                "{0}.{1}", 
                method.DeclaringType.FullName, 
                method.Name);
            ParameterInfo[] parameters = method.GetParameters();
            if (parameters.Length != 0)
            {
                string[] parameterTypeNames = parameters.Select(param => GetTypeName(param.ParameterType)).ToArray();
                name += string.Format(CultureInfo.InvariantCulture, "({0})", string.Join(",", parameterTypeNames));
            }

            return name;
        }

        /// <summary>
        /// The get tag value.
        /// </summary>
        /// <param name="parentNode">
        /// The parent node.
        /// </param>
        /// <param name="tagName">
        /// The tag name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetTagValue(XPathNavigator parentNode, string tagName)
        {
            if (parentNode != null)
            {
                XPathNavigator node = parentNode.SelectSingleNode(tagName);
                if (node != null)
                {
                    return node.Value.Trim();
                }
            }

            return null;
        }

        /// <summary>
        /// The get type name.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private static string GetTypeName(Type type)
        {
            if (type.IsGenericType)
            {
                // Format the generic type name to something like: Generic{System.Int32,System.String}
                Type genericType = type.GetGenericTypeDefinition();
                Type[] genericArguments = type.GetGenericArguments();
                string typeName = genericType.FullName;

                // Trim the generic parameter counts from the name
                typeName = typeName.Substring(0, typeName.IndexOf('`'));
                string[] argumentTypeNames = genericArguments.Select(t => GetTypeName(t)).ToArray();
                return string.Format(
                    CultureInfo.InvariantCulture, 
                    "{0}{{{1}}}", 
                    typeName, 
                    string.Join(",", argumentTypeNames));
            }

            return type.FullName;
        }

        /// <summary>
        /// The get method node.
        /// </summary>
        /// <param name="actionDescriptor">
        /// The action descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="XPathNavigator"/>.
        /// </returns>
        private XPathNavigator GetMethodNode(HttpActionDescriptor actionDescriptor)
        {
            var reflectedActionDescriptor = actionDescriptor as ReflectedHttpActionDescriptor;
            if (reflectedActionDescriptor != null)
            {
                string selectExpression = string.Format(
                    CultureInfo.InvariantCulture, 
                    MethodExpression, 
                    GetMemberName(reflectedActionDescriptor.MethodInfo));
                return this._documentNavigator.SelectSingleNode(selectExpression);
            }

            return null;
        }

        /// <summary>
        /// The get type node.
        /// </summary>
        /// <param name="controllerDescriptor">
        /// The controller descriptor.
        /// </param>
        /// <returns>
        /// The <see cref="XPathNavigator"/>.
        /// </returns>
        private XPathNavigator GetTypeNode(HttpControllerDescriptor controllerDescriptor)
        {
            Type controllerType = controllerDescriptor.ControllerType;
            string controllerTypeName = controllerType.FullName;
            if (controllerType.IsNested)
            {
                // Changing the nested type name from OuterType+InnerType to OuterType.InnerType to match the XML documentation syntax.
                controllerTypeName = controllerTypeName.Replace("+", ".");
            }

            string selectExpression = string.Format(CultureInfo.InvariantCulture, TypeExpression, controllerTypeName);
            return this._documentNavigator.SelectSingleNode(selectExpression);
        }

        #endregion
    }
}