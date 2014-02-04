namespace Bog.Extensions
{
    using Bog.Domain.Entities;

    /// <summary>
    /// The address extensions.
    /// </summary>
    public static class AddressExtensions
    {
        /// <summary>
        /// The to address string.
        /// </summary>
        /// <param name="address">
        /// The address.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToAddressString(this Address address)
        {
            return string.Format(
                "{0} {1}, {2}, {3} {4} {5}",
                address.Street1,
                address.Street2,
                address.City,
                address.State,
                address.PostalCode,
                address.Country);
        }
    }
}
