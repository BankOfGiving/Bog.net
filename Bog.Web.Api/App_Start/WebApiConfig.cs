namespace Bog.Web.Api
{
    using System.Linq;
    using System.Net.Http.Formatting;
    using System.Reflection;
    using System.Web.Http;

    using Bog.Domain.Entities.Contracts;

    using Microsoft.Owin.Security.OAuth;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    ///     The web API config.
    /// </summary>
    public static class WebApiConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// Web API configuration and services
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            JsonMediaTypeFormatter jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ContractResolver = new ExcludeBaseContractResolver<DomainEntityBase>();

            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.EnableCors();

            config.Routes.MapHttpRoute("DefaultApi", "{controller}/{id}", new { id = RouteParameter.Optional });
        }

        #endregion

        /// <summary>
        /// The exclude base contract resolver.
        /// </summary>
        /// <typeparam name="T">
        /// The type of entity to analyze.
        /// </typeparam>
        public class ExcludeBaseContractResolver<T> : DefaultContractResolver
            where T : class
        {
            #region Static Fields

            /// <summary>
            ///     The instance.
            /// </summary>
            public static readonly ExcludeBaseContractResolver<T> Instance = new ExcludeBaseContractResolver<T>();

            #endregion

            #region Methods

            /// <summary>
            /// The create property.
            /// </summary>
            /// <param name="member">
            /// The member.
            /// </param>
            /// <param name="memberSerialization">
            /// The member serialization.
            /// </param>
            /// <returns>
            /// The <see cref="JsonProperty"/>.
            /// </returns>
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                JsonProperty property = base.CreateProperty(member, memberSerialization);

                if (property.DeclaringType.BaseType == typeof(T) && property.PropertyName.Equals("EntityId"))
                {
                    // property.ShouldSerialize = instance => false;
                    property.Ignored = true;
                }

                return property;
            }

            #endregion
        }
    }
}