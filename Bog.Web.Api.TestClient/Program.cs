using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bog.Web.Api.TestClient
{
    using System.Net;
    using System.Runtime.Remoting.Messaging;

    class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        static void Main(string[] args)
        {
            const string requestUri = "http://localhost:4305/donation/654654654";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUri);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.Write(response.ToString());

            Console.Read();
        }
    }
}
