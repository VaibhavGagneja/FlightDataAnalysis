namespace FlightDataAnalysis.Business.Models
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides model inconsistent result.
    /// </summary>
    public class InconsistencyResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InconsistencyResult"/> class.
        /// </summary>
        /// <param name="inconsistentFlights">The inconsistent flights.</param>
        public InconsistencyResult(IReadOnlyCollection<FlightEntity> inconsistentFlights)
        {
            this.IsInconsistent = inconsistentFlights.Any();
            this.InconsistentFlights = inconsistentFlights.DistinctBy(x => x.Id).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InconsistencyResult"/> class.
        /// </summary>
        public InconsistencyResult()
        {
            this.IsInconsistent = false;
            this.InconsistentFlights = new List<FlightEntity>();
        }

        /// <summary>
        /// Gets a value indicating whether gets a value indicating flight chain is inconsistent or not.
        /// </summary>
        public bool IsInconsistent { get; private set; }

        /// <summary>
        /// Gets the inconsistent flights.
        /// </summary>
        public IReadOnlyCollection<FlightEntity> InconsistentFlights { get; private set; }
    }
}
