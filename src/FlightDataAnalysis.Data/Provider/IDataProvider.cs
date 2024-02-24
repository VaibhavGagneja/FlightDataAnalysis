namespace FlightDataAnalysis.Data.Provider
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions to get data set.
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Gets all flights.
        /// </summary>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{FlightEntity}"/>.</returns>
        IReadOnlyCollection<FlightEntity> GetFlights();

        /// <summary>
        /// Gets the flight by id.
        /// </summary>
        /// <param name="id">The flight id.</param>
        /// <returns>returns an instance of <see cref="FlightEntity"/>.</returns>
        FlightEntity GetFlightById(int id);
    }
}
