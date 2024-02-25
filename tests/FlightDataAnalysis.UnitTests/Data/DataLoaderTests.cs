using FlightDataAnalysis.Data.Loader;
using FlightDataAnalysis.Data.Models;
using FlightDataAnalysis.Data.Reader;
using FlightDataAnalysis.Data.Source;
using Moq;

namespace FlightDataAnalysis.UnitTests.Data
{
    /// <summary>
    /// Unit tests for data loader <see cref="DataLoader"/>.
    /// </summary>
    [TestFixture]
    public class DataLoaderTests
    {
        /// <summary>
        /// Validates whether data source is read and set.
        /// </summary>
        [Test]
        public void Load_ShouldReadAndSetData_InDataSource()
        {
            var mockDataSource = new Mock<IDataSource>();
            var mockDataReader = new Mock<IDataReader>();
            var dataLoader = new DataLoader(mockDataSource.Object, mockDataReader.Object);

            var config = new DataLoaderConfig
            {
                Path = "data/flights.csv",
                Delimiter = ",",
            };

            var entities = new List<FlightEntity>
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

            mockDataReader.Setup(dr => dr.Read(config.Path, config.Delimiter)).Returns(entities);

            dataLoader.Load(config);

            mockDataSource.Verify(ds => ds.Set(entities), Times.Once);
        }
    }
}
