using Newtonsoft.Json;

namespace FlightDataAnalysis.Models.Response;

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
    /// Gets or sets aircraftRegistrationNumber.
    /// </summary>
    [JsonProperty(PropertyName = "aircraftRegistrationNumber")]
    public string AircraftRegistrationNumber { get; set; }
}
