namespace Bog.Data.Entities
{
    using System;

    /// <summary>
    /// The membership data.
    /// </summary>
    public class MembershipData
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the confirmation token.
        /// </summary>
        public string ConfirmationToken { get; set; }

        /// <summary>
        /// Gets or sets the create date.
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// Gets or sets the is confirmed.
        /// </summary>
        public bool? IsConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the last password failure date.
        /// </summary>
        public DateTime? LastPasswordFailureDate { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the password changed date.
        /// </summary>
        public DateTime? PasswordChangedDate { get; set; }

        /// <summary>
        /// Gets or sets the password failures since last success.
        /// </summary>
        public int PasswordFailuresSinceLastSuccess { get; set; }

        /// <summary>
        /// Gets or sets the password salt.
        /// </summary>
        public string PasswordSalt { get; set; }

        /// <summary>
        /// Gets or sets the password verification token.
        /// </summary>
        public string PasswordVerificationToken { get; set; }

        /// <summary>
        /// Gets or sets the password verification token expiration date.
        /// </summary>
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        #endregion
    }
}