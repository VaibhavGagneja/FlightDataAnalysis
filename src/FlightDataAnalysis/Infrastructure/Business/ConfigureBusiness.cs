namespace FlightDataAnalysis.Infrastructure.Business
{
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
            services.AddScoped<IServiceInitializer, ServiceInitializer>();

            return services;
        }
    }
}
