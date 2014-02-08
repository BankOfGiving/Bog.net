namespace Bog.Web.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;

    using Bog.Domain.Entities;
    using Bog.Domain.Repositories.Contracts;
    using Bog.Enumerations;
    using Bog.Logging;
    using Bog.Web.Api.Controllers.Contracts;

    /// <summary>
    ///     The donation controller.
    /// </summary>
    [RoutePrefix("donation")]
    public class DonationController : ApiController, IDonationController
    {
        #region Fields

        /// <summary>
        ///     The repo.
        /// </summary>
        private readonly IDonationRepository repo;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DonationController"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        public DonationController(IDonationRepository repo)
        {
            this.repo = repo;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The get.
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        [Route("")]
        [EnableCors("*", null, null)]
        public HttpResponseMessage Get()
        {
            IEnumerable<Donation> donations = this.repo.Get();

            HttpResponseMessage response = this.Request.CreateResponse(HttpStatusCode.OK, donations);

            return response;
        }

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
        public HttpResponseMessage Get(int id)
        {
            return this.Get(id, InstanceRange.None);
        }

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
        public HttpResponseMessage Get(int id, InstanceRange range)
        {
            switch (range)
            {
                case InstanceRange.All:
                    break;
                case InstanceRange.Next:
                    break;
                case InstanceRange.Future:
                    break;
                case InstanceRange.FutureIncludingToday:
                    break;
                case InstanceRange.None:
                    break;
            }

            Donation donation = this.repo.Get(0);
            return donation != null
                       ? this.Request.CreateResponse(HttpStatusCode.OK, donation)
                       : this.Request.CreateResponse(HttpStatusCode.NotFound);
        }

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
        public HttpResponseMessage Post([FromBody] Donation donation)
        {
            if (donation == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NoContent); // this.Request.CreateErrorResponse(, ex);
            }

            try
            {
                Donation processedDonation = this.repo.Save(donation);
                return this.Request.CreateResponse(HttpStatusCode.Created, processedDonation);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable); // this.Request.CreateErrorResponse(, ex);
            }
        }

        #endregion
    }
}