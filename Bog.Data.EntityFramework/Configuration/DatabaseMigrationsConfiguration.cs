namespace Bog.Data.EntityFramework
{
    using System.Data.Entity.Migrations;

    /// <summary>
    ///     The message board migrations configuration.
    /// </summary>
    public class DatabaseMigrationsConfiguration : DbMigrationsConfiguration<BogContext>
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DatabaseMigrationsConfiguration" /> class.
        /// </summary>
        public DatabaseMigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        #endregion
    }
}