namespace Bog.Data.EntityFramework.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using Bog.Data.Entities;

    /// <summary>
    /// The user configuration.
    /// </summary>
    public class UserConfiguration : EntityTypeConfiguration<UserData>
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfiguration"/> class.
        /// </summary>
        public UserConfiguration()
        {
            this.Property(p => p.Id).HasColumnOrder(0);

            this.Property(p => p.Username).IsRequired().HasMaxLength(200);

            this.Property(p => p.FirstName).IsOptional().HasMaxLength(100);

            this.Property(p => p.LastName).IsOptional().HasMaxLength(100);

            this.HasMany(a => a.Roles).WithMany(b => b.Users).Map(
                m =>
                    {
                        m.MapLeftKey("UserId");
                        m.MapRightKey("RoleId");
                        m.ToTable("webpages_UsersInRoles");
                    });
        }

        #endregion
    }
}