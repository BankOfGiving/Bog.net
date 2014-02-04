namespace Bog.Data.EntityFramework
{
    using System;
    using System.ComponentModel;
    using System.Data.Entity;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Runtime.Serialization;

    using Bog.Data.Entities;
    using Bog.Data.Entities.Contracts;
    using Bog.Data.EntityFramework.Configuration;

    /// <summary>
    /// The entity framework data context.
    /// </summary>
    public class BogContext : DbContext
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="BogContext" /> class.
        /// </summary>
        public BogContext()
            : base("name=BankOfGiving")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BogContext, DatabaseMigrationsConfiguration>());
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the donation data set.
        /// </summary>
        public DbSet<DonationData> DonationDataSet { get; set; }

        /// <summary>
        ///     Gets or sets the instance data set.
        /// </summary>
        public DbSet<InstanceData> InstanceDataSet { get; set; }

        /// <summary>
        ///     Gets or sets the tag data set.
        /// </summary>
        public DbSet<TagData> TagDataSet { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            modelBuilder.Configurations.Add(new DonationConfiguration());
            modelBuilder.Configurations.Add(new InstanceConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());

            // Membership tables
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new OAuthMembershipConfiguration());
            modelBuilder.Configurations.Add(new MembershipConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// The save changes.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int SaveChanges()
        {
            this.ApplyRules();
            return base.SaveChanges();
        }

        /// <summary>
        /// The apply rules.
        /// </summary>
        private void ApplyRules()
        {
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.Entity is IAuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                IAuditableEntity auditLog = (IAuditableEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    auditLog.CreatedAt = DateTime.UtcNow;
                }

                auditLog.ModifiedAt = DateTime.UtcNow;

                // TODO: Save to external audit log.
            }
        }


        #endregion
    }
}