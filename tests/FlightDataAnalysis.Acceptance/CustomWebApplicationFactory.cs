namespace FlightDataAnalysis.Acceptance
{
    using FlightDataAnalysis.Constants;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc.Testing;

    /// <summary>
    /// Custom web api factory.
    /// </summary>
    /// <typeparam name="TProgram">The program of web application.</typeparam>
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram>
        where TProgram : class
    {
        /// <inheritdoc/>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment(EnvironmentConstants.IntegrationTesting);
        }
    }
}
