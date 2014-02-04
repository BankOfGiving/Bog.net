namespace Bog.Data.EntityFramework.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using Bog.Data.Entities;

    /// <summary>
    /// The role configuration.
    /// </summary>
    public class RoleConfiguration : EntityTypeConfiguration<RoleData>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleConfiguration"/> class.
        /// </summary>
        public RoleConfiguration()
        {
            this.ToTable("webpages_Roles");
            this.HasKey(p => p.RoleId);
            this.Property(p => p.RoleName).HasMaxLength(256).IsRequired();
        }

        #endregion
    }
}