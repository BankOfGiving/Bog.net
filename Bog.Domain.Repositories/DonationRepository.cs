namespace Bog.Domain.Repositories
{
    using System;
    using System.Collections.Generic;

    using Bog.Data.Repositories;
    using Bog.Domain.Entities;
    using Bog.Domain.Repositories.Contracts;
    using Bog.Logging;

    /// <summary>
    ///     The donation repository.
    /// </summary>
    public class DonationRepository : IDonationRepository
    {
        #region Fields

        /// <summary>
        ///     The donation data.
        /// </summary>
        private readonly IDataWorker _worker;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DonationRepository"/> class.
        /// </summary>
        /// <param name="worker">
        /// </param>
        public DonationRepository(IDataWorker worker)
        {
            this._worker = worker;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The get donation headers only with no instances instances.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<Donation> Get()
        {
            return this._worker.Donations.GetAll();

            // return this.donationData.Get(InstanceRange.None);
        }

        /////// <summary>
        /////// The get with all instances.
        /////// </summary>
        /////// <returns>
        /////// The <see cref="IEnumerable"/>.
        /////// </returns>
        ////public IEnumerable<Donation> GetWithInstances()
        ////{
        ////    return this.donationData.Get(InstanceRange.All);
        ////}

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
        /////// The <see cref="IEnumerable"/>.
        /////// </returns>
        ////public IEnumerable<Donation> GetWithInstances(DateTime lowerDate, DateTime upperDate)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////#endregion

        ////#region Get Single

        /// <summary>
        /// The get donation.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Donation"/>.
        /// </returns>
        public Donation Get(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     The get donations including instances.
        /// </summary>
        /// <returns>
        ///     The <see cref="IEnumerable{T}" />.
        /// </returns>
        public IEnumerable<Donation> GetWithFutureInstances()
        {
            return this._worker.Donations.GetAll();

            // return this._worker.Donations.Get(InstanceRange.Future);
        }

        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="donation">
        /// The donation.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public Donation Save(Donation donation)
        {
            try
            {
                if (donation.DonationId.Equals(0))
                {
                    return donation; // this.donationData.Add(donation);
                }

                return donation; // this.donationData.Save(donation);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                throw;
            }
        }

        #endregion

        /////// <summary>
        /////// The get with future instances.
        /////// </summary>
        /////// <param name="id">
        /////// The id.
        /////// </param>
        /////// <returns>
        /////// The <see cref="Donation"/>.
        /////// </returns>
        ////public Donation GetWithFutureInstances(int id)
        ////{
        ////    throw new NotImplementedException();
        ////}

        /////// <summary>
        /////// The get with all instances.
        /////// </summary>
        /////// <param name="id">
        /////// The id.
        /////// </param>
        /////// <returns>
        /////// The <see cref="Donation"/>.
        /////// </returns>
        ////public Donation GetWithAllInstances(int id)
        ////{
        ////    throw new NotImplementedException();
        ////}
    }
}