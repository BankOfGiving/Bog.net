namespace Bog.Data.Entities
{
    using System;
    using System.ComponentModel.Composition;
    using System.Data.Entity;

    using AutoMapper;

    using Bog.Composition;
    using Bog.Data.Entities.Contracts;
    using Bog.Domain.Entities;
    
    /// <summary>
    /// The instance data.
    /// </summary>
    public class InstanceData : DataEntityBase
    {
        /// <summary>
        /// Gets or sets the instance id.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        /// Gets or sets the donation.
        /// </summary>
        public virtual DonationData Donation { get; set; }

        /// <summary>
        /// Gets or sets the donation id.
        /// </summary>
        public int DonationId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        public decimal Longitude { get; set; }

        /// <summary>
        ///     Gets or sets the postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the street 1.
        /// </summary>
        public string Street1 { get; set; }

        /// <summary>
        ///     Gets or sets the street 2.
        /// </summary>
        public string Street2 { get; set; }

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// The entity mapping between domain entity and EF entity.
        /// </summary>
        [Export(typeof(IEntityMapping))]
        public class EntityMapping : IEntityMapping
        {
            /// <summary>
            /// The create map.
            /// </summary>
            /// <param name="mapper">
            /// The mapper.
            /// </param>
            public void CreateMap(IProfileExpression mapper)
            {
                // Domain >> EF
                mapper.CreateMap<Instance, InstanceData>();
                mapper.CreateMap<Location, InstanceData>();
                mapper.CreateMap<Address, InstanceData>();

                // EF >> Domain
                mapper.CreateMap<InstanceData, Instance>()
                    .ForMember(instance => instance.Location, options => options.MapFrom(location => Mapper.Map<InstanceData, Location>(location)))
                    .ForMember(instance => instance.Address, options => options.MapFrom(address => Mapper.Map<InstanceData, Address>(address)));        

                mapper.CreateMap<InstanceData, Location>()
                    .ForMember(location => location.Latitude, opt => opt.MapFrom(source => source.Latitude))
                    .ForMember(location => location.Longitude, opt => opt.MapFrom(source => source.Longitude));

                mapper.CreateMap<InstanceData, Address>()
                    .ForMember(address => address.City, opt => opt.MapFrom(source => source.City))
                    .ForMember(address => address.Country, opt => opt.MapFrom(source => source.Country))
                    .ForMember(address => address.PostalCode, opt => opt.MapFrom(source => source.PostalCode))
                    .ForMember(address => address.State, opt => opt.MapFrom(source => source.State))
                    .ForMember(address => address.Street1, opt => opt.MapFrom(source => source.Street1))
                    .ForMember(address => address.Street2, opt => opt.MapFrom(source => source.Street2));        
            }
        }
    }
}
