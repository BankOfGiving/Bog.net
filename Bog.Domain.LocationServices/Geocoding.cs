namespace Bog.Domain.LocationServices
{
    using System;

    using Bog.Domain.Entities;

    using Location = GoogleMapsApi.Entities.Common.Location;

    /// <summary>
    /// The service.
    /// </summary>
    public class Geocoding
    {
        /// <summary>
        /// The base uri.
        /// </summary>
        /// TODO: Move Api base uri to config file.  
        private readonly Uri BaseUri = new Uri("http://maps.googleapis.com/maps/api/geocode/json?sensor=false");

        /// <summary>
        /// The get geo location.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The <see cref="Location"/>.
        /// </returns>
        public Domain.Entities.Location Get(Address address)
        {
            ////GeocodingRequest geocodeRequest = new GeocodingRequest()
            ////{
            ////    Address = address.ToAddressString(),
            ////};
            ////GoogleMaps geocodingEngine = new GoogleMaps();
            ////GeocodingResponse geocode = geocodingEngine. .GetGeocode(geocodeRequest);

            return new Domain.Entities.Location();
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
        public Address Get(Domain.Entities.Location location)
        {
            ////string requestUri = string.Format(this.BaseUri, string.Format("&lat={0}&lng=");
            ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            ////HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return new Address();
        }

        /// <summary>
        /// The call.
        /// </summary>
        /// <param name="requestUri">
        /// The request uri.
        /// </param>
        private void Call(Uri requestUri)
        {
        }
    }
}
