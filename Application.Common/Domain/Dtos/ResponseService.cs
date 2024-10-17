using System.Net;

namespace Application.Common.Domain.Dtos
{
    public interface IResponseService
    {
    }

    public class ResponseService<T> : IResponseService
    {
        public bool Status { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public string Message { get; set; }
        public string[] Messages { get; set; }
        public T Data { get; set; }

        public int? ResultCount { get; set; }

        public ResponseService()
        {
            Status = false;
            Message = string.Empty;
        }

        public static ResponseService<T> Fail(string errorMessage)
        {
            return new ResponseService<T> { Status = false, Message = errorMessage };
        }

        public static ResponseService<T> Success(T data)
        {
            return new ResponseService<T> { Status = true, Data = data };
        }
    }
}
