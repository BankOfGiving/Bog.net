namespace Bog.Data.EntityFramework.Configuration
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.ModelConfiguration;

    using Bog.Data.Entities;

    /// <summary>
    ///     The membership configuration.
    /// </summary>
    public class MembershipConfiguration : EntityTypeConfiguration<MembershipData>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MembershipConfiguration" /> class.
        /// </summary>
        public MembershipConfiguration()
        {
            this.ToTable("webpages_Membership");
            this.HasKey(p => p.UserId);

            this.Property(p => p.UserId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.ConfirmationToken).HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordFailuresSinceLastSuccess).IsRequired();

            this.Property(p => p.Password).IsRequired().HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordSalt).IsRequired().HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordVerificationToken).HasMaxLength(128).HasColumnType("nvarchar");
        }

        #endregion
    }
}