using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ourProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next)
        {
            
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            try
            {
              await _next(httpContext);
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error From My Middleare: " + ex.Message + "Stack Tracre is: " + ex.StackTrace);
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            //return
            //await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
