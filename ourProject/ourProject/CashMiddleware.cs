using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourProject
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CashMiddleware
    {
        private readonly RequestDelegate _next;

        public CashMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
       
            return _next(httpContext);
        }
    }



    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CashMiddlewareExtensions
    {
        public static IApplicationBuilder UseCashMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CashMiddleware>();
        }
    }
}
