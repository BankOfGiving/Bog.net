namespace Bog.Data.EntityFramework.Configuration
{
    using System.Data.Entity.ModelConfiguration;

    using Bog.Data.Entities;

    /// <summary>
    /// The donation configuration.
    /// </summary>
    public class TagConfiguration : EntityTypeConfiguration<TagData>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagConfiguration"/> class. 
        /// </summary>
        public TagConfiguration()
        {
            //this.Property(p => p.StreetAddress)
            //    .IsRequired().HasMaxLength(100);

            //this.Property(p => p.StreetAddress2)
            //    .IsOptional().HasMaxLength(100);

            //this.Property(p => p.City)
            //    .IsRequired().HasMaxLength(50);

            //this.Property(p => p.ZipCode)
            //    .IsRequired();

            //this.Property(p => p.ImageName)
            //    .HasMaxLength(100);

            //this.Property(p => p.CreatedOn)
            //    .IsRequired().HasColumnType("datetime");

            //this.Property(p => p.ModifiedOn)
            //    .IsRequired().HasColumnType("datetime");

            this.Map(d => d.ToTable("Tags"))
                .HasKey(e => e.TagId);
        }
    }
}
