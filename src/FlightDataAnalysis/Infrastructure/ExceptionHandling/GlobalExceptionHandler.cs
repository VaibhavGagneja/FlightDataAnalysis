using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlightDataAnalysis.Infrastructure.ExceptionHandling
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            this.logger.LogError(
                $"An error occurred while processing your request: {exception.Message}");

            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = "An unhandled error occurred",
                Detail = exception.Message,
            };

            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
