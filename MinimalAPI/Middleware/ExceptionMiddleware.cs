using MinimalAPI.Models;
using System.Net;
using System.Text.Json;

namespace MinimalAPI.Middleware
{
    public sealed class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger logger)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                await GenerateExceptionResponse(e, context, (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task GenerateExceptionResponse(Exception e, HttpContext context, int statusCode, Dictionary<string, string[]> validationErrors = default)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var response = new ErrorDetails(context.Response.StatusCode, e.Message, e.StackTrace.Substring(0, 100));

            if(validationErrors != null)
            {
                response.ValidationErrors = validationErrors;
            }

            var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
