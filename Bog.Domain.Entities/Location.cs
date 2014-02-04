namespace Bog.Domain.Entities
{
    using System;

    using Bog.Domain.Entities.Contracts;

    /// <summary>
    ///     The location.
    /// </summary>
    public class Location : ILocation
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the latitude.
        /// </summary>
        public decimal Latitude { get; set; }

        /// <summary>
        ///     Gets or sets the longitude.
        /// </summary>
        public decimal Longitude { get; set; }

        #endregion

        #region Methods

        /// <summary>
        ///     The is location valid.
        /// </summary>
        /// <returns>
        ///     The <see cref="bool" />.
        /// </returns>
        private bool IsLocationValid()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}