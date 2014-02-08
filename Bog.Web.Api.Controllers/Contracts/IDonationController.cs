namespace Bog.Web.Api.Controllers.Contracts
{
    using System.Net.Http;
    using System.Web.Http;

    using Bog.Domain.Entities;
    using Bog.Enumerations;

    /// <summary>
    ///     The DonationController interface.
    /// </summary>
    public interface IDonationController
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The get.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        [Route("")]
        HttpResponseMessage Get();

        /// <summary>
        /// Returns a single donation matching the id with no instance information.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [Route("{id}")]
        HttpResponseMessage Get(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="range">
        /// The range.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [Route("{id}/Instances/{range}")]
        HttpResponseMessage Get(int id, InstanceRange range);

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="donation">
        /// The donation.
        /// </param>
        /// <returns>
        /// The <see cref="HttpResponseMessage"/>.
        /// </returns>
        [Route("")]
        HttpResponseMessage Post([FromBody] Donation donation);

        #endregion
    }
}