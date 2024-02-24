namespace FlightDataAnalysis.Data.Source
{
    using FlightDataAnalysis.Data.Models;

    /// <inheritdoc />
    public sealed class DataSource : IDataSource
    {
        private IReadOnlyCollection<FlightEntity> flightEntities;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataSource"/> class.
        /// </summary>
        public DataSource()
        {
            this.flightEntities = new List<FlightEntity>();
        }

        /// <inheritdoc />
        public void Set(IReadOnlyCollection<FlightEntity> entities)
        {
            this.flightEntities = entities;
        }

        /// <inheritdoc />
        public IReadOnlyCollection<FlightEntity> Get()
        {
            return this.flightEntities;
        }
    }
}
