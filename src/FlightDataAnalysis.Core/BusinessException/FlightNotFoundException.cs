namespace FlightDataAnalysis.Core.BusinessException
{
    /// <summary>
    /// Flight not found exception.
    /// </summary>
    public class FlightNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightNotFoundException"/> class.
        /// </summary>
        /// <param name="flightId">The flight id.</param>
        public FlightNotFoundException(string flightId)
            : base($"Flight not found by {flightId}")
        {
        }
    }
}
