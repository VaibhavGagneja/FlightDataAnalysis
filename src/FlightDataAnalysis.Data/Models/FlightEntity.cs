namespace FlightDataAnalysis.Data.Models;

/// <summary>
/// Provides for model for flight data entity.
/// </summary>
public class FlightEntity
{
    /// <summary>
    /// Gets or sets id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets aircraftRegistrationNumber.
    /// </summary>
    public string AircraftRegistrationNumber { get; set; }

    /// <summary>
    /// Gets or sets aircraftType.
    /// </summary>
    public string AircraftType { get; set; }

    /// <summary>
    /// Gets or sets flightNumber.
    /// </summary>
    public string FlightNumber { get; set; }

    /// <summary>
    /// Gets or sets departureAirport.
    /// </summary>
    public string DepartureAirport { get; set; }

    /// <summary>
    /// Gets or sets departureDatetime.
    /// </summary>
    public DateTime DepartureDatetime { get; set; }

    /// <summary>
    /// Gets or sets arrivalAirport.
    /// </summary>
    public string ArrivalAirport { get; set; }

    /// <summary>
    /// Gets or sets arrivalDatetime.
    /// </summary>
    public DateTime ArrivalDatetime { get; set; }
}
