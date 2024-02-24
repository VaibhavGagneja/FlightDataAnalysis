namespace FlightDataAnalysis.Data.Reader
{
    using System.Globalization;
    using CsvHelper;
    using CsvHelper.Configuration;
    using FlightDataAnalysis.Data.Models;

    /// <inheritdoc />
    public sealed class CsvDataReader : IDataReader
    {
        /// <inheritdoc />
        public IReadOnlyCollection<FlightEntity> Read(string path, string delimiter)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = delimiter, };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, configuration);
            var records = csv.GetRecords<FlightEntity>();

            return records.ToList();
        }
    }
}
