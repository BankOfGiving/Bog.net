namespace Bog.Domain.Common
{
    using System;

    using Bog.Domain.Entities.Contracts;

    public class TrackableEntity : ITrackableEntity
    {
        #region Fields

        /// <summary>
        ///     The acting account.
        /// </summary>
        private readonly IAccount actingAccount;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TrackableEntity"/> class.
        /// </summary>
        /// <param name="actingAccount">
        /// The acting account.
        /// </param>
        public TrackableEntity(IAccount actingAccount)
        {
            this.actingAccount = actingAccount;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the created at.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        public IAccount CreatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the modified at.
        /// </summary>
        public DateTime ModifiedAt { get; set; }

        /// <summary>
        ///     Gets or sets the modified by.
        /// </summary>
        public IAccount ModifiedBy { get; set; }

        #endregion
    }
}