namespace FlightDataAnalysis.Business.Services.Implementations
{
    using AutoMapper;
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Data.Models;
    using FlightDataAnalysis.Data.Provider;

    /// <inheritdoc />
    public class FlightAnalysisService : IFlightAnalysisService
    {
        private readonly IDataProvider provider;
        private readonly IInconsistencyValidator consistencyValidator;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightAnalysisService"/> class.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="consistencyValidator">The validation handler.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightAnalysisService(IDataProvider provider, IInconsistencyValidator consistencyValidator, IMapper mapper)
        {
            this.provider = provider;
            this.consistencyValidator = consistencyValidator;
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<Flight> GetAnalysisReport()
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

            return this.mapper.Map<IReadOnlyCollection<Flight>>(inConsistentFlights);
        }
    }
}
