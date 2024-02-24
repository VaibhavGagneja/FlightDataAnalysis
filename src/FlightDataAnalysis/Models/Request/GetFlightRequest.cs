namespace FlightDataAnalysis.Models.Request
{
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    /// <summary>
    /// Request model for flight data.
    /// </summary>
    public class GetFlightRequest
    {
        /// <summary>
        /// Gets or sets flight id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        [FromRoute]
        public string Id { get; set; }
    }
}
