namespace FlightDataAnalysis.UnitTests.Data
{
    using FlightDataAnalysis.Data.Models;
    using FluentAssertions;
    using CsvDataReader = FlightDataAnalysis.Data.Reader.CsvDataReader;

    /// <summary>
    /// CSV data reader unit tests.
    /// </summary>
    [TestFixture]
    public class CsvDataReaderTests
    {
        /// <summary>
        /// Validates whether csv reader reads data or not.
        /// </summary>
        [Test]
        public void ReadCSVFiles_ShouldReturn_FlightEntities()
        {
            var csvReader = new CsvDataReader();

            var entities = csvReader.Read("data/flights.csv", ",");

            var actual = new List<FlightEntity>
            {
                new ()
                {
                    ArrivalAirport = "DXB",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                    DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                    AircraftRegistrationNumber = "ZX-IKD",
                    AircraftType = "350",
                    FlightNumber = "M645",
                    Id = 1,
                },
                new ()
                {
                    ArrivalAirport = "OUL",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-30 15:30:00"),
                    DepartureDatetime = DateTime.Parse("2024-01-30 14:00:00"),
                    AircraftRegistrationNumber = "G-DIX",
                    AircraftType = "320",
                    FlightNumber = "AY120",
                    Id = 996,
                },
            };

            entities.Should().BeEquivalentTo(actual);
        }
    }
}
