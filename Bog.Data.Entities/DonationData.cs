namespace Bog.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.ComponentModel.DataAnnotations.Schema;

    using AutoMapper;

    using Bog.Composition;
    using Bog.Data.Entities.Contracts;
    using Bog.Domain.Entities;

    /// <summary>
    ///     The donation data.
    /// </summary>
    [Table("Donations")]
    public class DonationData : DataEntityBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        ////public DonationData(IAccount actingAccount)
        ////{
        ////}
        /// <summary>
        ///     Initializes a new instance of the <see cref="DonationData" /> class.
        /// </summary>
        /// <param name="actingAccount">
        ///     The acting account.
        /// </param>
        /// <summary>
        ///     Gets or sets the donation id.
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public virtual ICollection<TagData> Tags { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Gets or sets the type.
        /// </summary>
        public DonationTypeData Type { get; set; }

        #endregion

        /// <summary>
        ///     The entity mapping.
        /// </summary>
        [Export(typeof(IEntityMapping))]
        public class EntityMapping : IEntityMapping
        {
            #region Public Methods and Operators

            /// <summary>
            /// The register mapping definitions.
            /// </summary>
            /// <param name="mapper">
            /// The mapper.
            /// </param>
            public void CreateMap(IProfileExpression mapper)
            {
                Mapper.CreateMap<DonationData, Donation>();
                Mapper.CreateMap<Donation, DonationData>();
            }

            #endregion
        }
    }
}