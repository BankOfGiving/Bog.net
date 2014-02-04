namespace Bog.Data.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bog.Domain.Entities;
    using Bog.Enumerations;

    /// <summary>
    /// The DonationDataRepository interface.
    /// </summary>
    public interface IDonationDataRepository : IDisposable
    {
        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="donation">
        /// The donation.
        /// </param>
        /// <returns>
        /// The <see cref="Donation"/>.
        /// </returns>
        Donation Add(Donation donation);

        /// <summary>
        /// Get a single donation header by id with no instances.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Donation"/>.
        /// </returns>
        Donation Get(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="range">
        /// The range.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable{T}"/>.
        /// </returns>
        IEnumerable<Donation> Get(InstanceRange range);

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="donation">
        /// The donation.
        /// </param>
        /// <returns>
        /// The <see cref="Donation"/>.
        /// </returns>
        Donation Save(Donation donation);
    }
}