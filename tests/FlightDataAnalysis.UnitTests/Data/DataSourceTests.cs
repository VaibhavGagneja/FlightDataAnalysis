using FlightDataAnalysis.Data.Models;
using FlightDataAnalysis.Data.Source;
using FluentAssertions;

namespace FlightDataAnalysis.UnitTests.Data
{
    /// <summary>
    /// Data Source Unit tests.
    /// </summary>
    [TestFixture]
    public class DataSourceTests
    {
        /// <summary>
        /// Validates whether entities are properly set or not.
        /// </summary>
        [Test]
        public void SetFlightEntities_ShouldSet_FlightEntities()
        {
            var dataSource = new DataSource();
            var entities = new List<FlightEntity>
            {
                new ()
                {
                    ArrivalAirport = "HEL",
                    DepartureAirport = "OLU",
                    ArrivalDatetime = DateTime.Now,
                    DepartureDatetime = DateTime.Now,
                    AircraftRegistrationNumber = "MH01",
                    AircraftType = "BOY",
                    FlightNumber = "##001",
                    Id = 1,
                },
            };

            dataSource.Set(entities);

            entities.Should().BeEquivalentTo(dataSource.Get());
        }

        /// <summary>
        /// Validates whether initial source is empty list or not.
        /// </summary>
        [Test]
        public void InitiallySource_ShouldReturn_EmptyCollection()
        {
            var dataSource = new DataSource();

            var result = dataSource.Get();

            result.Should().BeEmpty();
        }
    }
}
