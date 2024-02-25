using FlightDataAnalysis.Business.Models;
using FlightDataAnalysis.Business.Services.Implementations.ValidationChain;
using FlightDataAnalysis.Data.Models;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Business
{
    /// <summary>
    /// Unit test for <see cref="PrerequisiteHandler"/>.
    /// </summary>
    [TestFixture]
    public class PrerequisiteHandlerTests
    {
        /// <summary>
        /// Validates prerequisite tests when base is not called.
        /// </summary>
        [Test]
        public void Validate_WithOneOrLessEntities_ShouldReturnInconsistencyResult()
        {
            var prerequisiteHandler = new PrerequisiteHandler();

            var oneEntity = new List<FlightEntity>
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
            };

            var resultOneEntity = prerequisiteHandler.Validate(oneEntity);
            var resultNoEntity = prerequisiteHandler.Validate(new List<FlightEntity>());

            resultOneEntity.Should().BeEquivalentTo(new InconsistencyResult());
            resultNoEntity.Should().BeEquivalentTo(new InconsistencyResult());
        }

        /// <summary>
        /// Validates prerequisite handler when base is called.
        /// </summary>
        [Test]
        public void Validate_WithMoreThanOneEntity_ShouldCallBaseValidation()
        {
            var prerequisiteHandler = new PrerequisiteHandler();

            var moreThanOneEntity = new List<FlightEntity>
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

            var mockValidationHandler = new Moq.Mock<ValidationHandler>();
            mockValidationHandler.Setup(x => x.Validate(It.IsAny<IReadOnlyCollection<FlightEntity>>()))
                .Returns(new InconsistencyResult());

            prerequisiteHandler.SetNext(mockValidationHandler.Object);

            prerequisiteHandler.Validate(moreThanOneEntity);

            mockValidationHandler.Verify(handler => handler.Validate(moreThanOneEntity), Times.Once);
        }
    }
}
