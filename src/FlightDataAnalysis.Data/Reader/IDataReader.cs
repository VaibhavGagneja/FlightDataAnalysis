namespace FlightDataAnalysis.Data.Reader
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides action to read data.
    /// </summary>
    public interface IDataReader
    {
        /// <summary>
        /// Reads the data from file.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{FlightEntity}"/>.</returns>
        IReadOnlyCollection<FlightEntity> Read(string path, string delimiter);
    }
}
