namespace FlightDataAnalysis.Infrastructure.Mvc
{
    public static class ConfigureMvc
    {
        public static IServiceCollection RegisterMvc(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
