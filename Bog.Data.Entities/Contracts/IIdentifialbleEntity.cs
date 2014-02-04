namespace Bog.Data.Entities.Contracts
{
    /// <summary>
    /// The identifiable entity.
    /// </summary>
    public interface IIdentifiableEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the entity id.
        /// </summary>
        int EntityId { get; set; }

        #endregion
    }
}
