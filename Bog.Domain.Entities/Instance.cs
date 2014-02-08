namespace Bog.Domain.Entities
{
    using System;

    using Bog.Domain.Entities.Contracts;

    /// <summary>
    ///     The instance.
    /// </summary>
    public class Instance : DomainEntityBase, IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the entity id.
        /// </summary>
        public int EntityId
        {
            get
            {
                return this.InstanceId;
            }

            set
            {
                this.InstanceId = value;
            }
        }

        /// <summary>
        ///     Gets or sets the instance id.
        /// </summary>
        public int InstanceId { get; set; }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        public DateTime Start { get; set; }

        #endregion
    }
}