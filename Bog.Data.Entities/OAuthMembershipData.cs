namespace Bog.Data.Entities
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The o auth membership metadata.
    /// </summary>
    [ScaffoldTable(false)]
    public class OAuthMembershipMetadata
    {
    }

    /// <summary>
    /// The o auth membership data.
    /// </summary>
    [MetadataType(typeof(OAuthMembershipMetadata))]
    public class OAuthMembershipData
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the provider.
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Gets or sets the provider user id.
        /// </summary>
        public string ProviderUserId { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        #endregion
    }
}