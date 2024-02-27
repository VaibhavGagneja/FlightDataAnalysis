namespace FlightDataAnalysis.Business.Models
{
    using Newtonsoft.Json;

    /// <summary>
    /// Flight option data transfer object.
    /// </summary>
    public class FlightOption
    {
        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets flightNumber.
        /// </summary>
        [JsonProperty(PropertyName = "flightNumber")]
        public string FlightNumber { get; set; }
    }
}
