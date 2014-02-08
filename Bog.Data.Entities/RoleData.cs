namespace Bog.Data.Entities
{
    using System.Collections.Generic;

    /// <summary>
    ///     The role.
    /// </summary>
    public class RoleData
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="RoleData" /> class.
        /// </summary>
        public RoleData()
        {
            this.Users = new List<UserData>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the role id.
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        ///     Gets or sets the role name.
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        ///     Gets or sets the users.
        /// </summary>
        public ICollection<UserData> Users { get; set; }

        #endregion
    }
}