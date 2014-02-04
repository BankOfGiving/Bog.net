namespace Bog.Domain.Repositories.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Bog.Domain.Entities;

    /// <summary>
    /// The DonationRepository interface.
    /// </summary>
    public interface IDonationRepository
    {
        /// <summary>
        /// The get donation headers only with no instances instances.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<Donation> Get();

        /////// <summary>
        /////// The get donations including instances.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="IEnumerable{T}"/>.
        /////// </returns>
        ////IEnumerable<Donation> GetWithFutureInstances();

        /////// <summary>
        /////// The get with all instances.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="IEnumerable{T}"/>.
        /////// </returns>
        ////IEnumerable<Donation> GetWithInstances();

        /////// <summary>
        /////// The get with instances within date range.
        /////// </summary>
        /////// <param name="lowerDate">
        /////// The lower date.
        /////// </param>
        /////// <param name="upperDate">
        /////// The upper date.
        /////// </param>
        /////// <returns>
        /////// The <see cref="IEnumerable{T}"/>.
        /////// </returns>
        ////IEnumerable<Donation> GetWithInstances(DateTime lowerDate, DateTime upperDate);

        /// <summary>
        /// The get donation.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Donation"/>.
        /// </returns>
        Donation Get(int id);

        /////// <summary>
        /////// The get with future instances.
        /////// </summary>
        /////// <param name="id">
        /////// The id.
        /////// </param>
        /////// <returns>
        /////// The <see cref="Donation"/>.
        /////// </returns>
        ////Donation GetWithFutureInstances(int id);

        /////// <summary>
        /////// The get with all instances.
        /////// </summary>
        /////// <param name="id">
        /////// The id.
        /////// </param>
        /////// <returns>
        /////// The <see cref="Donation"/>.
        /////// </returns>
        ////Donation GetWithAllInstances(int id);

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="donation">
        /// The donation.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        Donation Save(Donation donation);
    }
}