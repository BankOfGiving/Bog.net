namespace Bog.Domain.Entities.Contracts
{
    public interface ILocation
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        decimal Longitude { get; set; }

        #endregion
    }
}