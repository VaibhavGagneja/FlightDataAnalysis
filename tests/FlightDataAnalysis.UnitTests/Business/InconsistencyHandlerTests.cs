using FlightDataAnalysis.Business.Models;
using FlightDataAnalysis.Business.Services.Implementations.ValidationChain;
using FlightDataAnalysis.Data.Models;
using FluentAssertions;
using Moq;

namespace FlightDataAnalysis.UnitTests.Business
{
    /// <summary>
    /// Unit tests for <see cref="InconsistencyHandler"/>.
    /// </summary>
    [TestFixture]
    public class InconsistencyHandlerTests
    {
        /// <summary>
        /// Validates validate method. 
        /// </summary>
        [Test]
        public void Validate_ShouldReturnInconsistencyResult()
        {
            // Arrange
            var inconsistencyHandler = new InconsistencyHandler();

            var inconsistentFlights = new List<FlightEntity>
            {
                new ()
                {
                    DepartureDatetime = DateTime.Now,
                    ArrivalDatetime = DateTime.Now.AddHours(2),
                    DepartureAirport = "Airport1",
                    ArrivalAirport = "Airport2",
                    Id = 1,
                },
                new ()
                {
                    DepartureDatetime = DateTime.Now.AddHours(1),
                    ArrivalDatetime = DateTime.Now.AddHours(5),
                    DepartureAirport = "Airport2",
                    ArrivalAirport = "Airport1",
                    Id = 2,
                },
            };

            var result = inconsistencyHandler.Validate(inconsistentFlights);

            result.IsInconsistent.Should().BeTrue();

            inconsistentFlights.Should().BeEquivalentTo(result.InconsistentFlights);
        }

        /// <summary>
        /// Validates validate function when there is no inconsistency.
        /// </summary>
        [Test]
        public void Validate_WithConsistentFlights_ShouldCallBaseValidation()
        {
            var inconsistencyHandler = new InconsistencyHandler();

            var consistentFlights = new List<FlightEntity>
            {
                new ()
                {
                    DepartureDatetime = DateTime.Now,
                    ArrivalDatetime = DateTime.Now.AddHours(2),
                    DepartureAirport = "Airport1",
                    ArrivalAirport = "Airport2",
                    Id = 1,
                },
                new ()
                {
                    DepartureDatetime = DateTime.Now.AddHours(3),
                    ArrivalDatetime = DateTime.Now.AddHours(5),
                    DepartureAirport = "Airport2",
                    ArrivalAirport = "Airport1",
                    Id = 2,
                },
            };

            var mockValidationHandler = new Moq.Mock<ValidationHandler>();
            mockValidationHandler.Setup(x => x.Validate(It.IsAny<IReadOnlyCollection<FlightEntity>>()))
                .Returns(new InconsistencyResult());
            inconsistencyHandler.SetNext(mockValidationHandler.Object);

            var result = inconsistencyHandler.Validate(consistentFlights);

            result.IsInconsistent.Should().BeFalse();
            mockValidationHandler.Verify(handler => handler.Validate(consistentFlights), Moq.Times.Once);
        }
    }
}
