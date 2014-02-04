namespace Bog.Data.Repositories
{
    using Bog.Data.Entities;
    using Bog.Data.EntityFramework;
    using Bog.Data.Repositories.Contracts;
    using Bog.Data.Repositories.EntityFramework;
    using Bog.Domain.Entities;

    /// <summary>
    ///     The worker.
    /// </summary>
    public class DataWorker : IDataWorker
    {
        #region Fields

        /// <summary>
        ///     The _context.
        /// </summary>
        private readonly BogContext _context;

        /// <summary>
        ///     The _donations.
        /// </summary>
        private IRepository<DonationData, Donation> _donations;

        /// <summary>
        ///     The _instances.
        /// </summary>
        private IRepository<InstanceData, Instance> _instances;

        /// <summary>
        ///     The _tags.
        /// </summary>
        private IRepository<TagData, Tag> _tags;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataWorker"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public DataWorker(BogContext context)
        {
            this._donations = null;
            this._context = context;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the donations.
        /// </summary>
        public IRepository<DonationData, Donation> Donations
        {
            get
            {
                return this._donations ?? (this._donations = new DataRepository<DonationData, Donation>(this._context));
            }
        }

        /// <summary>
        ///     Gets the instances.
        /// </summary>
        public IRepository<InstanceData, Instance> Instances
        {
            get
            {
                return this._instances ?? (this._instances = new DataRepository<InstanceData, Instance>(this._context));
            }
        }

        /// <summary>
        ///     Gets the tags.
        /// </summary>
        public IRepository<TagData, Tag> Tags
        {
            get
            {
                return this._tags ?? (this._tags = new DataRepository<TagData, Tag>(this._context));
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The dispose.
        /// </summary>
        public void Dispose()
        {
            this._context.Dispose();
        }

        /// <summary>
        ///     The save changes.
        /// </summary>
        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        #endregion
    }
}