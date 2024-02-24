namespace FlightDataAnalysis.Infrastructure.Swagger
{
    /// <summary>
    /// Provides actions to register swagger dependencies.
    /// </summary>
    public static class ConfigureSwagger
    {
        /// <summary>
        /// Registers swagger dependencies.
        /// </summary>
        /// <param name="serviceCollection">The service collection.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen();

            return serviceCollection;
        }
    }
}
