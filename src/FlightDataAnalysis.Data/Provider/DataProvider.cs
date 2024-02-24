namespace FlightDataAnalysis.Data.Provider
{
    using FlightDataAnalysis.Data.Models;
    using FlightDataAnalysis.Data.Source;

    /// <inheritdoc />
    public sealed class DataProvider : IDataProvider
    {
        private readonly IDataSource dataSource;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProvider"/> class.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        public DataProvider(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<FlightEntity> GetFlights()
        {
            return this.dataSource.Get();
        }

        /// <inheritdoc />
        public FlightEntity GetFlightById(int id)
        {
            return this.dataSource.Get().FirstOrDefault(x => x.Id == id);
        }
    }
}
