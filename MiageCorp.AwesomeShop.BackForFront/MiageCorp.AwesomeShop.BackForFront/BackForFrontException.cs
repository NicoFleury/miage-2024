using System.Net;

namespace MiageCorp.AwesomeShop.BackForFront
{

    public class BackForFrontException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public BackForFrontException(HttpStatusCode statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
