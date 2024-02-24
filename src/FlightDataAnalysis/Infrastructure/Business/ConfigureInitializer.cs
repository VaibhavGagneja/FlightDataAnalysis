namespace FlightDataAnalysis.Infrastructure.Business
{
    /// <summary>
    /// Configures service initializer.
    /// </summary>
    public static class ConfigureInitializer
    {
        /// <summary>
        /// Registers data dependencies.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterInitializer(this IServiceCollection services)
        {
            services.AddScoped<IServiceInitializer, ServiceInitializer>();

            return services;
        }
    }
}
