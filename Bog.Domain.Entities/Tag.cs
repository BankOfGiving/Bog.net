namespace Bog.Domain.Entities
{
    /// <summary>
    ///     The tag.
    /// </summary>
    public class Tag
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        public int TagId { get; set; }

        #endregion
    }
}