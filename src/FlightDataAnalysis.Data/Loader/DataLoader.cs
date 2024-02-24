namespace FlightDataAnalysis.Data.Loader
{
    using FlightDataAnalysis.Data.Models;
    using FlightDataAnalysis.Data.Reader;
    using FlightDataAnalysis.Data.Source;

    /// <inheritdoc />
    public sealed class DataLoader : IDataLoader
    {
        private readonly IDataSource dataSource;
        private readonly IDataReader dataReader;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataLoader"/> class.
        /// </summary>
        /// <param name="dataSource">The data source.</param>
        /// <param name="dataReader">The data reader.</param>
        public DataLoader(IDataSource dataSource, IDataReader dataReader)
        {
            this.dataSource = dataSource;
            this.dataReader = dataReader;
        }

        /// <inheritdoc />
        public void Load(DataLoaderConfig config)
        {
            var entities = this.dataReader.Read(config.Path, config.Delimiter);

            this.dataSource.Set(entities);
        }
    }
}
