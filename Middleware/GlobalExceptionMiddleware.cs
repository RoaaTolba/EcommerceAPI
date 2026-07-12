using ecommerceAPI.Domain.Exceptions;
using ecommerceAPI.Responses;
using System.Text.Json;
using System.Threading.Tasks;

namespace ecommerceAPI.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionMiddleware> logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger <GlobalExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context,ex);
            }
        }
        public Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            int statusCode = ex switch
            {
                BaseException baseEx => baseEx.StatusCode,
                _ => StatusCodes.Status500InternalServerError
            };
            var response = new ErrorResponse
            {
                Message = ex.Message,
                StatusCode = statusCode,
            };
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
