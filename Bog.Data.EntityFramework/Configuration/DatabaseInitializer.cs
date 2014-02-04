namespace Bog.Data.EntityFramework.Configuration
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Bog.Data.Entities;

    /// <summary>
    /// The database initializer.
    /// </summary>
    /// <typeparam name="T">
    /// Type of data context
    /// </typeparam>
    public class DatabaseInitializer<T> : DropCreateDatabaseIfModelChanges<T> where T : BogContext
    {
        /// <summary>
        /// The seed.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Seed(T context)
        {
#if DEBUG
            var newDonation = new DonationData
            {
                Title = "Sample Donation",
                Description = "This is the description of the sample donation.",
                //Instances =
                //    new List<InstanceData>
                //                              {
                //                                  new InstanceData
                //                                      {
                //                                          Start = DateTime.UtcNow,  
                //                                          End = DateTime.UtcNow.AddDays(1),
                //                                          Latitude = (decimal)34.130909, 
                //                                          Longitude = (decimal)-118.071957,
                //                                          Street1 = "879 Michigan Blvd.",
                //                                          Street2 = "Unit N",
                //                                          City = "Pasadena",
                //                                          Country = "US",
                //                                          PostalCode = "91107",
                //                                          State = "CA",
                //                                          Description = "We're giving away items at my house."
                //                                      }
                //                              },
                Tags = new List<TagData>
                           {
                               new TagData { Name = "Home" },
                               new TagData { Name = "Local" },
                               new TagData { Name = "Pasadena" },
                               new TagData { Name = "Offer" }
                           }

            };

            context.DonationDataSet.Add(newDonation);
            context.SaveChanges();
#endif

            base.Seed(context);
        }
    }
}