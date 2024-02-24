namespace FlightDataAnalysis.Data.Provider
{
    /// <summary>
    /// Provides actions to get data set.
    /// </summary>
    public interface IDataProvider
    {
        void GetFlights();

        void GetFlightById(int id);
    }
}
