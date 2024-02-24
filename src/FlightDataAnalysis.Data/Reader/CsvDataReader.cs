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
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            using var reader = new StreamReader(absolutePath);
            using var csv = new CsvReader(reader, configuration);
            csv.Context.RegisterClassMap<FlightEntityClassMap>();
            var records = csv.GetRecords<FlightEntity>();

            return records.ToList();
        }
    }
}
