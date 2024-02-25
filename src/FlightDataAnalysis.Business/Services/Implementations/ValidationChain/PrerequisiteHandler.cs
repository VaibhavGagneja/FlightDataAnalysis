namespace FlightDataAnalysis.Business.Services.Implementations.ValidationChain
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Data.Models;

    /// <inheritdoc />
    public class PrerequisiteHandler : ValidationHandler
    {
        /// <inheritdoc/>
        public override InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities)
        {
            return flightEntities.Count <= 1 ? new InconsistencyResult() : base.Validate(flightEntities);
        }
    }
}
