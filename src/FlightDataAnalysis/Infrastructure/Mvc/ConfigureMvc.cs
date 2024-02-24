namespace FlightDataAnalysis.Infrastructure.Mvc
{
    using Asp.Versioning;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// Provides actions to configure mvc setting.
    /// </summary>
    public static class ConfigureMvc
    {
        /// <summary>
        /// Registers mvc dependencies.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>returns an instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection RegisterMvc(this IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            });

            services.AddEndpointsApiExplorer();
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.ReportApiVersions = true;
                o.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("X-Version"),
                    new MediaTypeApiVersionReader("ver"));
            });

            return services;
        }
    }
}
