namespace FlightDataAnalysis.Infrastructure.AutoMapper;

/// <summary>
/// Provides actions to register auto mapper.
/// </summary>
public static class ConfigureAutoMapper
{
    /// <summary>
    /// Registers auto mapper.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program));

        return services;
    }
}
