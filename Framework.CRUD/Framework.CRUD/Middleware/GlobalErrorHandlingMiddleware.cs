using System;
using System.Net;
using System.Threading.Tasks;
using Framework.CRUD.Exceptions;
using Framework.CRUD.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Framework.CRUD.Middleware
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errors = new DefaultErrors();
            HandleNotFoundException(context, ex, errors);
            HandleConflictException(context, ex, errors);
            HandleClientException(context, ex, errors);
            HandleUnknownExceptions(context,ex, errors);

            var json = JsonConvert.SerializeObject(errors);
            return context.Response.WriteAsync(json);;
        }

        private static void HandleUnknownExceptions(HttpContext context, Exception ex, DefaultErrors errors)
        {
            if (errors.ErrorList.Count > 1) return;
            const HttpStatusCode code = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            errors.Reject("UNKNOWN", "Unknown Exception Occurred");
        }
        
        private static void HandleClientException(HttpContext context, Exception ex, DefaultErrors errors)
        {
            if (!(ex is ClientException)) return;
            const HttpStatusCode code = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var clientException = (ClientException) ex;
            errors.Reject(clientException.ErrorCode, clientException.Message, clientException.Message);
        }

        private static void HandleConflictException(HttpContext context, Exception ex, DefaultErrors errors)
        {
            if (!(ex is ConflictException)) return;
            const HttpStatusCode code = HttpStatusCode.Conflict;
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var clientException = (ClientException) ex;
            errors.Reject(clientException.ErrorCode, clientException.Message, clientException.Message);
        }
        
        private static void HandleNotFoundException(HttpContext context, Exception ex, DefaultErrors errors)
        {
            if (!(ex is NotFoundException)) return;
            const HttpStatusCode code = HttpStatusCode.NotFound;
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var clientException = (ClientException) ex;
            errors.Reject(clientException.ErrorCode, clientException.Message, clientException.Message);
        }
    }
}