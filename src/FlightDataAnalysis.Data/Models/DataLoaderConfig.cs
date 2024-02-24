namespace FlightDataAnalysis.Data.Models
{
    using FlightDataAnalysis.Data.Constants;

    /// <summary>
    /// Provides data loader config.
    /// </summary>
    public class DataLoaderConfig
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets delimiter.
        /// </summary>
        public string Delimiter { get; set; } = DataLoaderConstants.DefaultDelimiter;
    }
}
