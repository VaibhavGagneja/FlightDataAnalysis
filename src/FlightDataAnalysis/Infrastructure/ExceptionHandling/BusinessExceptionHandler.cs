namespace FlightDataAnalysis.Infrastructure.ExceptionHandling
{
    using System.Net;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.Extensions.Logging;

    public class BusinessExceptionHandler(ILogger<BusinessExceptionHandler> logger): IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError($"Bad request exception: {exception.Message}");
            if (exception is not BadHttpRequestException badRequestException)
            {
                return false;
            }

            var errorResponse = new
            {
                StatusCode = (int)HttpStatusCode.UnprocessableEntity, 
                Message = badRequestException.Message,
            };
            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
