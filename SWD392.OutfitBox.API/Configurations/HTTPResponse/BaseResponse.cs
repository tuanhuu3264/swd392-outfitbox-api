using System.Net;
using System.Runtime.CompilerServices;

namespace SWD392.OutfitBox.API.Configurations.HTTPResponse
{
    public class BaseResponse<T>
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; }
        public T? Data { get; set; }
        public BaseResponse(string message, HttpStatusCode statusCode , T? data)
        {
            Message = message;
            StatusCode = statusCode;
            Data = data;
        }
    }
}
