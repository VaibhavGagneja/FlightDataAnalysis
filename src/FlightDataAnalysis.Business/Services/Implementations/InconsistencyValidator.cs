namespace FlightDataAnalysis.Business.Services.Implementations
{
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Data.Models;

    /// <inheritdoc />
    public class InconsistencyValidator : IInconsistencyValidator
    {
        private readonly IValidationHandler validationHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="InconsistencyValidator"/> class.
        /// </summary>
        /// <param name="validationHandler">The validator.</param>
        public InconsistencyValidator(IValidationHandler validationHandler)
        {
            this.validationHandler = validationHandler;
        }

        /// <inheritdoc/>
        public InconsistencyResult Validate(IReadOnlyCollection<FlightEntity> flightEntities)
        {
            return this.validationHandler.Validate(flightEntities);
        }
    }
}
