namespace FlightDataAnalysis.Business.Services
{
    using FlightDataAnalysis.Business.Models;

    /// <summary>
    /// Provides actions to retrieve flights.
    /// </summary>
    public interface IFlightService
    {
        /// <summary>
        /// Gets all flights.
        /// </summary>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{Flight}"/>.</returns>
        IReadOnlyCollection<Flight> GetFlights();

        /// <summary>
        /// Gets flight by id.
        /// </summary>
        /// <param name="id">The flight id.</param>
        /// <returns>returns an instance of flight id.</returns>
        Flight GetFlightById(int id);

        /// <summary>
        /// Gets flight options.
        /// </summary>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{FlightOption}"/>.</returns>
        IReadOnlyCollection<FlightOption> GetFlightOptions();
    }
}
