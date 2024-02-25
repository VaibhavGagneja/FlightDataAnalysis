using FlightDataAnalysis.Business.Models;
using FlightDataAnalysis.Business.Services;
using FlightDataAnalysis.Business.Services.Implementations;
using FlightDataAnalysis.Data.Models;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Business
{
    /// <summary>
    /// Unit tests for <see cref="InconsistencyValidator"/>.
    /// </summary>
    [TestFixture]
    public class InconsistencyValidatorTests
    {
        /// <summary>
        /// Validates inconsistencies.
        /// </summary>
        [Test]
        public void Validate_ShouldReturnInconsistencyResultFromValidationHandler()
        {
            var mockValidationHandler = new Mock<IValidationHandler>();
            var inconsistencyValidator = new InconsistencyValidator(mockValidationHandler.Object);

            var flightEntities = new List<FlightEntity>
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

            var expectedResult = new InconsistencyResult();

            mockValidationHandler.Setup(handler => handler.Validate(flightEntities)).Returns(expectedResult);

            var result = inconsistencyValidator.Validate(flightEntities);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
