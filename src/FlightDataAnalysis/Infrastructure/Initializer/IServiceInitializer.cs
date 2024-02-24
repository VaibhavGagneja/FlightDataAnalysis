namespace FlightDataAnalysis.Infrastructure.Initializer;

/// <summary>
/// Provides actions to initialize the service.
/// </summary>
public interface IServiceInitializer
{
    /// <summary>
    /// Initializes the service.
    /// </summary>
    void Initialize();
}
