using Domain.LoggerManager;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager logger;
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        {
            this.next = next;
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
            catch (ValidationException MyEx)
            {
                logger.LogError(MyEx.Message + " " + MyEx);
                await HandleExceptionAsync(httpContext, MyEx);

            }
            catch (Exception ex)
            {
                logger.LogError("Something went wrong: " + ex);
                await HandleExceptionAsync(httpContext, ex);

            }

        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";


            var message = exception switch
            {
                AccessViolationException => "Access violation error from the custom middleware",
                _ => "Internal Server Error from the custom middleware."
            };
            if (exception is ValidationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Conflict;

            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }.ToString());
        }

    }
}
