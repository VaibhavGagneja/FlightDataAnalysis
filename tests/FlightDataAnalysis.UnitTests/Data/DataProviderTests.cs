using FlightDataAnalysis.Data.Models;
using FlightDataAnalysis.Data.Provider;
using FlightDataAnalysis.Data.Source;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Data
{
    /// <summary>
    /// Data provider class unit tests.
    /// </summary>
    [TestFixture]
    public class DataProviderTests
    {
        /// <summary>
        /// Validates flights from data source.
        /// </summary>
        [Test]
        public void GetFlights_ShouldReturn_FlightEntitiesFromDataSource()
        {
            var mockDataSource = new Mock<IDataSource>();
            var dataProvider = new DataProvider(mockDataSource.Object);

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

            mockDataSource.Setup(ds => ds.Get()).Returns(entities);

            var result = dataProvider.GetFlights();

            entities.Should().BeEquivalentTo(result);
        }

        /// <summary>
        /// Validates flight get by id.
        /// </summary>
        [Test]
        public void GetFlightById_ShouldReturnCorrectFlightEntity()
        {
            var mockDataSource = new Mock<IDataSource>();
            var dataProvider = new DataProvider(mockDataSource.Object);

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

            mockDataSource.Setup(ds => ds.Get()).Returns(entities);

            var result = dataProvider.GetFlightById(1);
            var actual = new FlightEntity()
            {
                ArrivalAirport = "DXB",
                DepartureAirport = "HEL",
                ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                AircraftRegistrationNumber = "ZX-IKD",
                AircraftType = "350",
                FlightNumber = "M645",
                Id = 1,
            };

            result.Should().BeEquivalentTo(actual);
        }

        /// <summary>
        /// Validates when flight does not exist.
        /// </summary>
        [Test]
        public void GetFlightById_ShouldReturnNull()
        {
            var mockDataSource = new Mock<IDataSource>();
            var dataProvider = new DataProvider(mockDataSource.Object);

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

            mockDataSource.Setup(ds => ds.Get()).Returns(entities);

            var result = dataProvider.GetFlightById(3);

            result.Should().BeNull();
        }
    }
}
