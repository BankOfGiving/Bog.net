namespace Bog.Domain.LocationServices
{
    using System;

    using Bog.Domain.Entities;

    /// <summary>
    ///     The service.
    /// </summary>
    public class Geocoding
    {
        #region Fields

        /// <summary>
        ///     The base uri.
        /// </summary>
        /// TODO: Move Api base uri to config file.
        private readonly Uri BaseUri = new Uri("http://maps.googleapis.com/maps/api/geocode/json?sensor=false");

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The get geo location.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The <see cref="GoogleMapsApi.Entities.Common.Location"/>.
        /// </returns>
        public Location Get(Address address)
        {
            ////GeocodingRequest geocodeRequest = new GeocodingRequest()
            ////{
            ////    Address = address.ToAddressString(),
            ////};
            ////GoogleMaps geocodingEngine = new GoogleMaps();
            ////GeocodingResponse geocode = geocodingEngine. .GetGeocode(geocodeRequest);
            return new Location();
        }

        /// <summary>
        /// The get geo location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="Address"/>.
        /// </returns>
        public Address Get(Location location)
        {
            ////string requestUri = string.Format(this.BaseUri, string.Format("&lat={0}&lng=");
            ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            ////HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            return new Address();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The call.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        private void Call(Uri requestUri)
        {
        }

        #endregion
    }
}