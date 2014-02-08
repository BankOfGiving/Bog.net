namespace Bog.Domain.Entities
{
    using System;

    /// <summary>
    ///     The address.
    /// </summary>
    public class Address
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     Gets or sets the country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        ///     Gets or sets the postal code.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Gets or sets the state.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Gets or sets the street 1.
        /// </summary>
        public string Street1 { get; set; }

        /// <summary>
        ///     Gets or sets the street 2.
        /// </summary>
        public string Street2 { get; set; }

        #endregion

        #region Methods

        private bool IsAddressValid()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}