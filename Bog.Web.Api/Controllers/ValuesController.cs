namespace Bog.Web.Api.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    [Authorize]
    public class ValuesController : ApiController
    {
        // GET api/values
        #region Public Methods and Operators

        public void Delete(int id)
        {
        }

        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        #endregion

        // DELETE api/values/5
    }
}