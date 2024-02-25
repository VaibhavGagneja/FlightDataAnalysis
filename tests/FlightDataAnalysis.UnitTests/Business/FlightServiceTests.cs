using AutoMapper;
using FlightDataAnalysis.Business.Models;
using FlightDataAnalysis.Business.Services.Implementations;
using FlightDataAnalysis.Core.BusinessException;
using FlightDataAnalysis.Data.Models;
using FlightDataAnalysis.Data.Provider;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Business
{
    /// <summary>
    /// Unit tests for <see cref="FlightService"/>.
    /// </summary>
    [TestFixture]
    public class FlightServiceTests
    {
        /// <summary>
        /// Validates get flights.
        /// </summary>
        [Test]
        public void GetFlights_ShouldReturn_MappedFlights()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var mockMapper = new Mock<IMapper>();

            var flightService = new FlightService(mockDataProvider.Object, mockMapper.Object);

            var dataEntities = new List<FlightEntity>
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

            var mappedFlights = new List<Flight>
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

            mockDataProvider.Setup(dp => dp.GetFlights()).Returns(dataEntities);
            mockMapper.Setup(m => m.Map<IReadOnlyCollection<Flight>>(dataEntities)).Returns(mappedFlights);

            var result = flightService.GetFlights();

            CollectionAssert.AreEqual(mappedFlights, result);

            result.Should().BeEquivalentTo(mappedFlights);
        }

        /// <summary>
        /// Validates get flight by id.
        /// </summary>
        [Test]
        public void GetFlightById_WithExistingId_ShouldReturnMappedFlight()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var mockMapper = new Mock<IMapper>();

            var flightService = new FlightService(mockDataProvider.Object, mockMapper.Object);

            var dataEntity = new FlightEntity
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
            var mappedFlight = new Flight
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

            mockDataProvider.Setup(dp => dp.GetFlightById(It.IsAny<int>())).Returns(dataEntity);
            mockMapper.Setup(m => m.Map<Flight>(dataEntity)).Returns(mappedFlight);

            var result = flightService.GetFlightById(1);

            result.Should().BeEquivalentTo(mappedFlight);
        }

        /// <summary>
        /// Validates whether throws exception or not.
        /// </summary>
        [Test]
        public void GetFlightById_ShouldThrowEntityNotFoundException()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var mockMapper = new Mock<IMapper>();

            var flightService = new FlightService(mockDataProvider.Object, mockMapper.Object);

            mockDataProvider.Setup(dp => dp.GetFlightById(It.IsAny<int>())).Returns((FlightEntity)null);

            Assert.Throws<EntityNotFoundException>(() => flightService.GetFlightById(1));
        }

        /// <summary>
        /// Validates flight options.
        /// </summary>
        [Test]
        public void GetFlightOptions_ShouldReturnMappedFlightOptions()
        {
            var mockDataProvider = new Mock<IDataProvider>();
            var mockMapper = new Mock<IMapper>();

            var flightService = new FlightService(mockDataProvider.Object, mockMapper.Object);

            var dataEntities = new List<FlightEntity>
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

            var mappedFlightOptions = new List<FlightOption>
            {
                new ()
                {
                    Id = 1,
                    AircraftRegistrationNumber = "ZX-IKD",
                },
                new ()
                {
                    Id = 996,
                    AircraftRegistrationNumber = "G-DIX",
                },
            };

            mockDataProvider.Setup(dp => dp.GetFlights()).Returns(dataEntities);
            mockMapper.Setup(m => m.Map<IReadOnlyCollection<FlightOption>>(dataEntities)).Returns(mappedFlightOptions);

            var result = flightService.GetFlightOptions();

            mappedFlightOptions.Should().BeEquivalentTo(result);
        }
    }
}
