namespace FlightDataAnalysis.Business.Services.Implementations.ValidationChain
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Data.Models;

    /// <inheritdoc />
    public abstract class ValidationHandler : IValidationHandler
    {
        private IValidationHandler nextHandler;

        /// <inheritdoc />
        public IValidationHandler SetNext(IValidationHandler handler)
        {
            this.nextHandler = handler;

            return handler;
        }

        /// <inheritdoc />
        public virtual InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities)
        {
            return this.nextHandler == null ? new InconsistencyResult() : this.nextHandler.Validate(flightEntities);
        }
    }
}
