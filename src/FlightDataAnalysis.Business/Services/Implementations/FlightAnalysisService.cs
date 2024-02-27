namespace FlightDataAnalysis.Business.Services.Implementations
{
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Data.Models;
    using FlightDataAnalysis.Data.Provider;

    /// <inheritdoc />
    public class FlightAnalysisService : IFlightAnalysisService
    {
        private readonly IDataProvider provider;
        private readonly IInconsistencyValidator consistencyValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightAnalysisService"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="consistencyValidator">The validation handler.</param>
        public FlightAnalysisService(IDataProvider provider, IInconsistencyValidator consistencyValidator)
        {
            this.provider = provider;
            this.consistencyValidator = consistencyValidator;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<FlightEntity> GetAnalysisReport()
        {
            var flights = this.provider.GetFlights();
            var flightGroups = flights.GroupBy(x => x.AircraftRegistrationNumber);
            var inConsistentFlights = new List<FlightEntity>();

            foreach (var flight in flightGroups)
            {
                var validationResult = this.consistencyValidator.Validate(flight.ToList());

                if (validationResult.IsInconsistent)
                {
                    inConsistentFlights.AddRange(validationResult.InconsistentFlights.ToList());
                }
            }

            return inConsistentFlights;
        }
    }
}
