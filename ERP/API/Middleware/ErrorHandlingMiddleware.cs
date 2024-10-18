using Infrastructure.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, _logger);
               
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex, ILogger<ErrorHandlingMiddleware> logger)
        {
            object errors = null;

            switch (ex)
            {
                case RestException restException:
                    logger.LogError(ex, "Rest Error");

                    errors = restException._Errors;
                    httpContext.Response.StatusCode = (int)restException._Code; 
                    break;

                case Exception e:
                    logger.LogError(e, "Server Error");
                    errors = string.IsNullOrWhiteSpace(e.Message)? "Error" : e.Message;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            httpContext.Response.ContentType = "application/json";
            if(errors != null)
            {
                var result = JsonConvert.SerializeObject(new { errors });
                await httpContext.Response.WriteAsync(result);
            }
        }
    }
}
