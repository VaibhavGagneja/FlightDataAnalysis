namespace FlightDataAnalysis.Business.Services.Implementations.ValidationChain
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Inconsistent validation handler.
    /// </summary>
    public class InconsistencyHandler : ValidationHandler
    {
        /// <inheritdoc/>
        public override InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities)
        {
            var orderedFlights = flightEntities.OrderBy(x => x.DepartureDatetime).ToList();
            var inConsistentFlights = new List<FlightEntity>();

            for (int i = 0; i < orderedFlights.Count - 1; i++)
            {
                var currentFlight = orderedFlights[i];
                var nextFlight = orderedFlights[i + 1];

                if (currentFlight.ArrivalAirport.Equals(
                        nextFlight.DepartureAirport,
                        StringComparison.InvariantCultureIgnoreCase)
                    && currentFlight.DepartureAirport.Equals(
                        nextFlight.ArrivalAirport,
                        StringComparison.InvariantCultureIgnoreCase)
                    && nextFlight.DepartureDatetime.Subtract(currentFlight.ArrivalDatetime).TotalSeconds > 0)
                {
                    continue;
                }

                inConsistentFlights.Add(nextFlight);
            }

            return inConsistentFlights.Any()
                ? new InconsistencyResult(inConsistentFlights)
                : base.Validate(flightEntities);
        }
    }
}
