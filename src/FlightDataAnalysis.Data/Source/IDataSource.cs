namespace FlightDataAnalysis.Data.Source
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions on data source.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// Sets the data on data source.
        /// </summary>
        /// <param name="entities">The flight entities.</param>
        void Set(IReadOnlyCollection<FlightEntity> entities);

        /// <summary>
        /// Gets the data from source.
        /// </summary>
        /// <returns>returns <see cref="IReadOnlyCollection{FlightEntity}"/>.</returns>
        IReadOnlyCollection<FlightEntity> Get();
    }
}
