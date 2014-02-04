namespace Bog.Data.Entities.Contracts
{
    using System;

    /// <summary>
    /// The data entity base.
    /// </summary>
    public class DataEntityBase : IAuditableEntity
    {
        public IAccount CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public IAccount ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
