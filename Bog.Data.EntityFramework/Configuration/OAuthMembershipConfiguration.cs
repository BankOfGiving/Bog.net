namespace Bog.Data.EntityFramework.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using Bog.Data.Entities;

    /// <summary>
    ///     The OAuth membership configuration.
    /// </summary>
    public class OAuthMembershipConfiguration : EntityTypeConfiguration<OAuthMembershipData>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="OAuthMembershipConfiguration" /> class.
        /// </summary>
        public OAuthMembershipConfiguration()
        {
            this.ToTable("webpages_OAuthMembership");

            this.HasKey(k => new { k.Provider, k.ProviderUserId });

            this.Property(p => p.Provider).HasColumnType("nvarchar").HasMaxLength(30).IsRequired();

            this.Property(p => p.ProviderUserId).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            this.Property(p => p.UserId).IsRequired();
        }

        #endregion
    }
}