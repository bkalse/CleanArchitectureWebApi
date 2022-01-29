using System;

namespace CleanCQRS.Models.Common
{
    //public class Response<T> : IResponse//<T>
    public class Response : IResponse
    {
        public bool Succeeded { get; set; }
        public bool Warning { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public Response()
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Exception = null;
        }
    }
}
