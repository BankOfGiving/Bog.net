namespace Bog.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.Runtime.Serialization;

    using Bog.Data.Entities.Contracts;

    /// <summary>
    /// The audit entry.
    /// </summary>
    public class AuditEntry : IExtensibleDataObject
    {
        /// <summary>
        /// Gets or sets the entity name.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Gets or sets the entity state.
        /// </summary>
        public EntityState EntityState { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        public IAccount ActionBy { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        public DateTime ActionAt { get; set; }

        /// <summary>
        /// Gets or sets the extension data.
        /// </summary>
        public ExtensionDataObject ExtensionData { get; set; }
    }
}
