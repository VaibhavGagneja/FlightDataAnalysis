namespace FlightDataAnalysis.Data.Loader
{
    /// <summary>
    /// Provides actions to load data set.
    /// </summary>
    public interface IDataLoader
    {
        /// <summary>
        /// Loads data set into system.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Load();
    }
}
