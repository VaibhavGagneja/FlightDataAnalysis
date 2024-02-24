namespace FlightDataAnalysis.Models.Response;

/// <summary>
/// Error response for business validation.
/// </summary>
public class BusinessErrorResponse
{
    /// <summary>
    /// Gets or sets status code.
    /// </summary>
    [JsonProperty(PropertyName = "statusCode")]
    public int StatusCode { get; set; }

    /// <summary>
    /// Gets or sets error message.
    /// </summary>
    [JsonProperty(PropertyName = "errorMessage")]
    public string ErrorMessage { get; set; }
}
