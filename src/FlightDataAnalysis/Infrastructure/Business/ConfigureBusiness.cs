namespace FlightDataAnalysis.Infrastructure.Business
{
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Business.Services.Implementations;

    /// <summary>
    /// Provides actions to register business dependencies.
    /// </summary>
    public static class ConfigureBusiness
    {
        /// <summary>
        /// Registers business dependencies.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterBusiness(this IServiceCollection services)
        {
            services.AddScoped<IFlightService, FlightService>();
            services.AddScoped<IFlightAnalysisService, FlightAnalysisService>();

            return services;
        }
    }
}
