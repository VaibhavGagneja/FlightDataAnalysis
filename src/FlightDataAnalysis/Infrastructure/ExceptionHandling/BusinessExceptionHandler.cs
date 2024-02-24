namespace FlightDataAnalysis.Infrastructure.ExceptionHandling
{
    using System.Net;
    using FlightDataAnalysis.Core.BusinessException;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// Custom exception handler for business validation.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public class BusinessExceptionHandler(ILogger<BusinessExceptionHandler> logger) : IExceptionHandler
    {
        /// <summary>
        /// Handles business exception.
        /// </summary>
        /// <param name="httpContext">The http context.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>returns an instance of <see cref="ValueTask"/>.</returns>
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError($"Bad request exception: {exception.Message}");
            if (exception is not BusinessException businessException)
            {
                return false;
            }

            var errorResponse = new BusinessErrorResponse
            {
                StatusCode = (int)HttpStatusCode.UnprocessableEntity,
                ErrorMessage = businessException.Message,
            };
            httpContext.Response.StatusCode = errorResponse.StatusCode;
            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
