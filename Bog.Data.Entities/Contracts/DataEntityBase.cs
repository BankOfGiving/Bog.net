namespace Bog.Data.Entities.Contracts
{
    using System;

    /// <summary>
    ///     The data entity base.
    /// </summary>
    public class DataEntityBase : IAuditableEntity
    {
        #region Public Properties

        public DateTime CreatedAt { get; set; }
        public IAccount CreatedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public IAccount ModifiedBy { get; set; }

        #endregion
    }
}