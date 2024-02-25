namespace FlightDataAnalysis.Business.Services
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions for validations.
    /// </summary>
    public interface IValidationHandler
    {
        /// <summary>
        /// Sets the next validation.
        /// </summary>
        /// <param name="handler">The validation handler.</param>
        /// <returns>returns an instance of <see cref="IValidationHandler"/>.</returns>
        IValidationHandler SetNext(IValidationHandler handler);

        /// <summary>
        /// Validates the flights.
        /// </summary>
        /// <param name="flightEntities">The co-related flights.</param>
        /// <returns>returns true when valid otherwise false.</returns>
        InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities);
    }
}
