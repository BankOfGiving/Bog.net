namespace Bog.Data.Entities.Contracts
{
    /// <summary>
    /// The Account interface.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }
    }
}