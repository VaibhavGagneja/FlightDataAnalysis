namespace FlightDataAnalysis.Data.Reader
{
    using CsvHelper.Configuration;
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Provides Flight entity class map.
    /// </summary>
    public sealed class FlightEntityClassMap : ClassMap<FlightEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightEntityClassMap"/> class.
        /// </summary>
        public FlightEntityClassMap()
        {
            this.Map(x => x.Id).Name("id");
            this.Map(x => x.AircraftRegistrationNumber).Name("aircraft_registration_number");
            this.Map(x => x.AircraftType).Name("aircraft_type");
            this.Map(x => x.FlightNumber).Name("flight_number");
            this.Map(x => x.DepartureAirport).Name("departure_airport");
            this.Map(x => x.DepartureDatetime).Name("departure_datetime");
            this.Map(x => x.ArrivalAirport).Name("arrival_airport");
            this.Map(x => x.ArrivalDatetime).Name("arrival_datetime");
        }
    }
}
