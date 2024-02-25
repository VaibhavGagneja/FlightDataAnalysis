using FlightDataAnalysis.Business.Models;
using FlightDataAnalysis.Business.Services;
using FlightDataAnalysis.Business.Services.Implementations;
using FlightDataAnalysis.Data.Models;
using FlightDataAnalysis.Data.Provider;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Business
{
    /// <summary>
    /// Unit tests for <see cref="FlightAnalysisService"/>.
    /// </summary>
    [TestFixture]
    public class FlightAnalysisServiceTests
    {
        /// <summary>
        /// Validates inconsistent flights.
        /// </summary>
        [Test]
        public void GetAnalysisReport_ShouldReturn_InconsistentFlights()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var mockValidator = new Mock<IInconsistencyValidator>();

            var flightAnalysisService = new FlightAnalysisService(mockDataProvider.Object, mockValidator.Object);

            var flights = new List<FlightEntity>
            {
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
                new ()
                {
                    ArrivalAirport = "OUL",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-30 15:30:00"),
                    DepartureDatetime = DateTime.Parse("2024-01-30 14:00:00"),
                    AircraftRegistrationNumber = "G-DIX",
                    AircraftType = "320",
                    FlightNumber = "AY120",
                    Id = 995,
                },
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
                    ArrivalAirport = "DXB",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                    DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                    AircraftRegistrationNumber = "ZX-IKDT",
                    AircraftType = "350",
                    FlightNumber = "M645",
                    Id = 2,
                },
                new ()
                {
                    ArrivalAirport = "DXB",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                    DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                    AircraftRegistrationNumber = "ZX-IKDT",
                    AircraftType = "350",
                    FlightNumber = "M645",
                    Id = 3,
                },
            };

            var inconsistentFlights = new List<FlightEntity>
            {
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
                new ()
                {
                    ArrivalAirport = "OUL",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-30 15:30:00"),
                    DepartureDatetime = DateTime.Parse("2024-01-30 14:00:00"),
                    AircraftRegistrationNumber = "G-DIX",
                    AircraftType = "320",
                    FlightNumber = "AY120",
                    Id = 995,
                },
                new ()
                {
                    ArrivalAirport = "DXB",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                    DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                    AircraftRegistrationNumber = "ZX-IKDT",
                    AircraftType = "350",
                    FlightNumber = "M645",
                    Id = 2,
                },
                new ()
                {
                    ArrivalAirport = "DXB",
                    DepartureAirport = "HEL",
                    ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                    DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                    AircraftRegistrationNumber = "ZX-IKDT",
                    AircraftType = "350",
                    FlightNumber = "M645",
                    Id = 3,
                },
            };

            mockDataProvider.Setup(dp => dp.GetFlights()).Returns(flights);

            mockValidator.SetupSequence(v => v.Validate(It.IsAny<IReadOnlyCollection<FlightEntity>>()))
                .Returns(new InconsistencyResult(new List<FlightEntity>
                {
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
                    new ()
                    {
                        ArrivalAirport = "OUL",
                        DepartureAirport = "HEL",
                        ArrivalDatetime = DateTime.Parse("2024-01-30 15:30:00"),
                        DepartureDatetime = DateTime.Parse("2024-01-30 14:00:00"),
                        AircraftRegistrationNumber = "G-DIX",
                        AircraftType = "320",
                        FlightNumber = "AY120",
                        Id = 995,
                    },
                }))
                .Returns(new InconsistencyResult())
                .Returns(new InconsistencyResult(new List<FlightEntity>
                {
                    new ()
                    {
                        ArrivalAirport = "DXB",
                        DepartureAirport = "HEL",
                        ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                        DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                        AircraftRegistrationNumber = "ZX-IKDT",
                        AircraftType = "350",
                        FlightNumber = "M645",
                        Id = 2,
                    },
                    new ()
                    {
                        ArrivalAirport = "DXB",
                        DepartureAirport = "HEL",
                        ArrivalDatetime = DateTime.Parse("2024-01-03 02:31:27"),
                        DepartureDatetime = DateTime.Parse("2024-01-02 21:46:27"),
                        AircraftRegistrationNumber = "ZX-IKDT",
                        AircraftType = "350",
                        FlightNumber = "M645",
                        Id = 3,
                    },
                }));

            var result = flightAnalysisService.GetAnalysisReport();

            inconsistentFlights.Should().BeEquivalentTo(result);
        }
    }
}
