namespace Bog.Data.Entities
{
    using System.ComponentModel.Composition;

    using AutoMapper;

    using Bog.Composition;
    using Bog.Data.Entities.Contracts;
    using Bog.Domain.Entities;

    /// <summary>
    ///     The tag data.
    /// </summary>
    public class TagData : DataEntityBase
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the tag id.
        /// </summary>
        public int TagId { get; set; }

        #endregion

        /// <summary>
        ///     The entity mapping.
        /// </summary>
        [Export(typeof(IEntityMapping))]
        public class EntityMapping : IEntityMapping
        {
            #region Public Methods and Operators

            /// <summary>
            /// The create map.
            /// </summary>
            /// <param name="mapper">
            /// The mapper.
            /// </param>
            public void CreateMap(IProfileExpression mapper)
            {
                // TODO: Add reverse mapping.
                Mapper.CreateMap<TagData, Tag>();
                Mapper.CreateMap<Tag, TagData>();
            }

            #endregion
        }
    }
}