using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Stock.Api
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "plain/text";
                response.StatusCode = 500;
                await response.WriteAsync(exception.Message);
            }
        }
    }
}
