using Domain.LoggerManager;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CustomExeptionMiddleware
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;
        public ExeptionMiddleware(RequestDelegate next,ILoggerManager logger) 
        {
            this.next =next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext) 
        {
            try 
            {
                await next(httpContext);
            }
            catch (AccessViolationException avEx)
            {
                logger.LogError($"A new violation exception has been thrown: {avEx}");
                await HandleExceptionAsync(httpContext, avEx);
            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong: " +ex);
                await HandleExceptionAsync(httpContext,ex);

            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                _ => "Internal Server Error from the custom middleware."
            };
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error from the custom middleware."
            }.ToString());
        }

    }
}
