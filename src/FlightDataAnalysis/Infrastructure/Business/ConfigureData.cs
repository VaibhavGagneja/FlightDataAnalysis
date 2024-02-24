namespace FlightDataAnalysis.Infrastructure.Business
{
    using FlightDataAnalysis.Data.Loader;
    using FlightDataAnalysis.Data.Provider;
    using FlightDataAnalysis.Data.Reader;
    using FlightDataAnalysis.Data.Source;

    /// <summary>
    /// Provides actions to configure data dependencies.
    /// </summary>
    public static class ConfigureData
    {
        /// <summary>
        /// Registers data dependencies.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterData(this IServiceCollection services)
        {
            services.AddScoped<IDataLoader, DataLoader>();
            services.AddScoped<IDataReader, CsvDataReader>();
            services.AddScoped<IDataProvider, DataProvider>();
            services.AddSingleton<IDataSource, DataSource>();

            return services;
        }
    }
}
