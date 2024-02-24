namespace FlightDataAnalysis.Infrastructure.Configuration
{
    using FlightDataAnalysis.Models.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Provides actions to register options.
    /// </summary>
    public static class ConfigureOptions
    {
        private const string DataLoaderSettingKey = "DataLoaderSettings";

        /// <summary>
        /// Registers options.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions()
                .Configure<DataLoaderSetting>(configuration.GetSection(DataLoaderSettingKey));

            return services;
        }
    }
}
