namespace Bog.Data.Repositories
{
    using System;

    using Bog.Data.Entities;
    using Bog.Data.Repositories.Contracts;
    using Bog.Domain.Entities;

    /// <summary>
    /// The DataWorker interface.
    /// </summary>
    public interface IDataWorker : IDisposable
    {
        /// <summary>
        ///     Gets the donations.
        /// </summary>
        IRepository<DonationData, Donation> Donations { get; }

        /// <summary>
        ///     Gets the instances.
        /// </summary>
        IRepository<InstanceData, Instance> Instances { get; }

        /// <summary>
        ///     Gets the tags.
        /// </summary>
        IRepository<TagData, Tag> Tags { get; }

        /// <summary>
        ///     The dispose.
        /// </summary>
        void Dispose();

        /// <summary>
        ///     The save changes.
        /// </summary>
        void SaveChanges();
    }
}