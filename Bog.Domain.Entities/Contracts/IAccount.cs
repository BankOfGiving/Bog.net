namespace Bog.Domain.Entities.Contracts
{
    /// <summary>
    ///     The Account interface.
    /// </summary>
    public interface IAccount
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        #endregion
    }
}