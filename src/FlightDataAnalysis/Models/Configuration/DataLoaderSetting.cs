namespace FlightDataAnalysis.Models.Configuration
{
    /// <summary>
    /// Configuration setting for data loader.
    /// </summary>
    public class DataLoaderSetting
    {
        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// Gets or sets delimiter.
        /// </summary>
        public string Delimiter { get; set; }
    }
}
