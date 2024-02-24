namespace FlightDataAnalysis.Infrastructure.ExceptionHandling;

/// <summary>
/// Provides actions to register exception handlers.
/// </summary>
public static class ConfigureExceptionHandlers
{
    /// <summary>
    /// Registers exception handlers.
    /// </summary>
    /// <param name="serviceCollection">The service collection.</param>
    /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection RegisterExceptionHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddExceptionHandler<BusinessExceptionHandler>();
        serviceCollection.AddExceptionHandler<GlobalExceptionHandler>();
        serviceCollection.AddProblemDetails();

        return serviceCollection;
    }
}
