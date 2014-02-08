namespace Bog.Domain.Entities.Contracts
{
    using System;

    public interface IInstance
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        string Description { get; set; }

        /// <summary>
        ///     Gets or sets the end.
        /// </summary>
        DateTime End { get; set; }

        /// <summary>
        ///     Gets or sets the instance contact.
        /// </summary>
        string InstanceContact { get; set; }

        /// <summary>
        ///     Gets or sets the location.
        /// </summary>
        Location Location { get; set; }

        /// <summary>
        ///     Gets or sets the start.
        /// </summary>
        DateTime Start { get; set; }

        #endregion
    }
}