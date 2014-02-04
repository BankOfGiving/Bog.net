namespace Bog.Data.Entities.Contracts
{
    /// <summary>
    /// The AccountOwnedEntity interface.
    /// </summary>
    public interface IAccountOwnedEntity
    {
        #region Public Properties

        /// <summary>
        /// Gets the owner account id.
        /// </summary>
        int OwnerAccountId { get; }

        #endregion
    }
}
