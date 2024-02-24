namespace FlightDataAnalysis.Infrastructure.Swagger
{
    public static class ConfigureSwagger
    {
        public static IServiceCollection RegisterSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen();

            return serviceCollection;
        }
    }
}
