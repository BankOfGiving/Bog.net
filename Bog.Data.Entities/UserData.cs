namespace Bog.Data.Entities
{
    using System.Collections.Generic;

    /// <summary>
    ///     The user.
    /// </summary>
    public class UserData
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        public UserData()
        {
            this.Roles = new List<RoleData>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public ICollection<RoleData> Roles { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        #endregion
    }
}