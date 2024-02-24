namespace FlightDataAnalysis.Data.Loader
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides actions to load data set.
    /// </summary>
    public interface IDataLoader
    {
        /// <summary>
        /// Loads data set into system.
        /// </summary>
        /// <param name="config">The data loader config.</param>
        void Load(DataLoaderConfig config);
    }
}
