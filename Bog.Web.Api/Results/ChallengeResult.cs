namespace Bog.Web.Api.Results
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class ChallengeResult : IHttpActionResult
    {
        #region Constructors and Destructors

        public ChallengeResult(string loginProvider, ApiController controller)
        {
            this.LoginProvider = loginProvider;
            this.Request = controller.Request;
        }

        #endregion

        #region Public Properties

        public string LoginProvider { get; set; }
        public HttpRequestMessage Request { get; set; }

        #endregion

        #region Public Methods and Operators

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            this.Request.GetOwinContext().Authentication.Challenge(this.LoginProvider);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.RequestMessage = this.Request;
            return Task.FromResult(response);
        }

        #endregion
    }
}