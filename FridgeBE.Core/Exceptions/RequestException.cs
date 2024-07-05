using System.Net;

namespace FridgeBE.Core.Exceptions
{
    public class RequestException : Exception
    {
        public HttpStatusCode StatusCode {  get; set; }

        public RequestException(HttpStatusCode statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }

        public RequestException(HttpStatusCode statusCode, string? message, Exception? innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}