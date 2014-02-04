namespace Bog.Data.Repositories.EntityFramework
{
    using System.Collections.ObjectModel;
    using System.Linq;

    using AutoMapper;

    using Bog.Data.Entities;
    using Bog.Data.EntityFramework;

    /// <summary>
    ///     The donation repository.
    /// </summary>
    public class DonationDataRepository<T> : DataRepository<DonationData> where T : class 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DonationDataRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public DonationDataRepository(BogContext context)
            : base(context)
        {
        }

        public override IQueryable<T> GetAll()
        {
            var collection = base.GetAll();

            return Mapper.Map<IQueryable<DonationData>, IQueryable<T>>(collection);
        }

        ///// <summary>
        ///// The save.
        ///// </summary>
        ///// <param name="donation">
        ///// The donation.
        ///// </param>
        ///// <returns>
        ///// The <see cref="Donation"/>.
        ///// </returns>
        //public Donation Add(Donation donation)
        //{
        //    // Map domain to data entity
        //    var donationData = Mapper.Map<DonationData>(donation);

        //    // Add to collection
        //    this.Data.DonationDataSet.Add(donationData);

        //    // Commit
        //    this.Data.SaveChanges();

        //    return Mapper.Map<Donation>(donationData);
        //}

        ///// <summary>
        ///// Get a single donation header by id with no instances.
        ///// </summary>
        ///// <param name="id">
        ///// The id.
        ///// </param>
        ///// <returns>
        ///// The <see cref="Donation"/>.
        ///// </returns>
        //public Donation Get(int id)
        //{
        //    var donationData = this.Data.DonationDataSet.Single(d => d.DonationId == id);
        //    this.Data.Entry(donationData).Collection(d => d.Tags).Load();

        //    return Mapper.Map<Donation>(donationData);
        //}

        ///// <summary>
        ///// The get.
        ///// </summary>
        ///// <param name="range">
        ///// The range.
        ///// </param>
        ///// <returns>
        ///// The <see cref="IQueryable"/>.
        ///// </returns>
        //public IEnumerable<Donation> Get(InstanceRange range)
        //{
        //    var donationDataList = this.Data.DonationDataSet.ToList();

        //    foreach (DonationData donationData in donationDataList)
        //    {
        //        switch (range)
        //        {
        //            // TODO:  Change date filter to use account local time rather than server time.
        //            case InstanceRange.All:
        //                this.Data.Entry(donationData).Collection(d => d.Instances).Load();
        //                break;
        //            case InstanceRange.Future:
        //                this.Data.Entry(donationData).Collection(d => d.Instances)
        //                    .Query()
        //                    .Where(p => p.Start > DateTime.UtcNow)
        //                    .Load();
        //                break;
        //            case InstanceRange.FutureIncludingToday:
        //                this.Data.Entry(donationData).Collection(d => d.Instances)
        //                    .Query()
        //                    .Where(p => p.Start >= DateTime.UtcNow.StartOfDay())
        //                    .Load();
        //                break;
        //            case InstanceRange.Next:
        //                this.Data.Entry(donationData).Collection(d => d.Instances)
        //                    .Query()
        //                    .Where(p => p.Start > DateTime.UtcNow)
        //                    .Take(1)
        //                    .Load();
        //                break;
        //        }

        //        this.Data.Entry(donationData).Collection(d => d.Tags).Load();
        //    }

        //    return Mapper.Map<IEnumerable<Donation>>(donationDataList);
        //}

        ///// <summary>
        ///// The save.
        ///// </summary>
        ///// <param name="donation">
        ///// The donation.
        ///// </param>
        ///// <returns>
        ///// The <see cref="Donation"/>.
        ///// </returns>
        //public Donation Save(Donation donation)
        //{
        //    // Map domain to data entity
        //    var donationData = Mapper.Map<DonationData>(donation);

        //    // Add to collection
        //    this.Data.DonationDataSet.Attach(donationData);

        //    // Commit
        //    this.Data.SaveChanges();

        //    return Mapper.Map<Donation>(donationData);
        //}
    }
}