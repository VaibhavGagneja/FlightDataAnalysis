namespace FlightDataAnalysis.Business.Services
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions to validate flights for same aircraft.
    /// </summary>
    public interface IInconsistencyValidator
    {
        /// <summary>
        /// Validates the flights.
        /// </summary>
        /// <param name="flightEntities">The flights for the aircraft.</param>
        /// <returns>returns an instance of <see cref="InconsistencyResult"/>.</returns>
        InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities);
    }
}
