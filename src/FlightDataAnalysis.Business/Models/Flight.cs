namespace FlightDataAnalysis.Business.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Flight details data transfer object.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets aircraftRegistrationNumber.
        /// </summary>
        [JsonProperty(PropertyName = "aircraftRegistrationNumber")]
        public string AircraftRegistrationNumber { get; set; }

        /// <summary>
        /// Gets or sets aircraftType.
        /// </summary>
        [JsonProperty(PropertyName = "aircraftType")]
        public string AircraftType { get; set; }

        /// <summary>
        /// Gets or sets flightNumber.
        /// </summary>
        [JsonProperty(PropertyName = "flightNumber")]
        public string FlightNumber { get; set; }

        /// <summary>
        /// Gets or sets departureAirport.
        /// </summary>
        [JsonProperty(PropertyName = "departureAirport")]
        public string DepartureAirport { get; set; }

        /// <summary>
        /// Gets or sets departureDatetime.
        /// </summary>
        [JsonProperty(PropertyName = "departureDatetime")]
        public DateTime DepartureDatetime { get; set; }

        /// <summary>
        /// Gets or sets arrivalAirport.
        /// </summary>
        [JsonProperty(PropertyName = "arrivalAirport")]
        public string ArrivalAirport { get; set; }

        /// <summary>
        /// Gets or sets arrivalDatetime.
        /// </summary>
        [JsonProperty(PropertyName = "arrivalDatetime")]
        public DateTime ArrivalDatetime { get; set; }
    }
}
