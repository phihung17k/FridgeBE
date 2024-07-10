using System.Net;
using System.Text.Json.Serialization;

namespace FridgeBE.Core.Models.ResponseModels
{
    public class ResponseModelBase
    {
        [JsonIgnore]
        public HttpStatusCode? StatusCode { get; set; }

        [JsonIgnore]
        public string? ErrorMessage { get; set; }

        public ResponseModelBase()
        { }

        public ResponseModelBase(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    }
}