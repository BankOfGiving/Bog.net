namespace Bog.Data.Entities
{
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// The donation type data.
    /// </summary>
    public class DonationTypeData
    {
        /// <summary>
        /// Gets or sets the type id.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}