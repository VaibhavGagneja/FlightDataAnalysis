namespace FlightDataAnalysis.Business.Services
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions for flight analysis.
    /// </summary>
    public interface IFlightAnalysisService
    {
        /// <summary>
        /// Gets the flight analysis.
        /// </summary>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{FlightEntity}"/>.</returns>
        IReadOnlyCollection<FlightEntity> GetAnalysisReport();
    }
}
