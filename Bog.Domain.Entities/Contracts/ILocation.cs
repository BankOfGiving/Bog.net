namespace Bog.Domain.Entities.Contracts
{
    public interface ILocation
    {
        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        decimal Longitude { get; set; }
    }
}