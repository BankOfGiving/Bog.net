namespace Bog.Data.Entities.Contracts
{
    using System;

    /// <summary>
    ///     The Auditable Entity interface.
    /// </summary>
    public interface IAuditableEntity
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the created at.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        ///     Gets or sets the created by.
        /// </summary>
        IAccount CreatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the modified at.
        /// </summary>
        DateTime ModifiedAt { get; set; }

        /// <summary>
        ///     Gets or sets the last modified by.
        /// </summary>
        IAccount ModifiedBy { get; set; }

        #endregion
    }
}