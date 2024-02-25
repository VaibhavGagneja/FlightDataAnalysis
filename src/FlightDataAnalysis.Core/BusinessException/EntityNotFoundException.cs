namespace FlightDataAnalysis.Core.BusinessException
{
    /// <summary>
    /// Flight not found exception.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotFoundException"/> class.
        /// </summary>
        /// <param name="entity">The entity name.</param>
        /// <param name="flightId">The flight id.</param>
        public EntityNotFoundException(string entity, string flightId)
            : base($"{entity} not found by {flightId}")
        {
        }
    }
}
