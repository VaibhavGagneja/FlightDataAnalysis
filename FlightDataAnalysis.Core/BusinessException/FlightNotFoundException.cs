namespace FlightDataAnalysis.Core.BusinessException
{
    public class FlightNotFoundException(string flightId) : BusinessException($"Flight not found by {flightId}");
}
