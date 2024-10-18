using System;
using System.Net;

namespace Infrastructure.Common
{
    public class RestException : Exception
    {
        public RestException(HttpStatusCode code, object errors = null)
        {
            _Code = code;
            _Errors = errors;
        }

        public HttpStatusCode _Code { get; }
        public object _Errors { get; }
    }
}
