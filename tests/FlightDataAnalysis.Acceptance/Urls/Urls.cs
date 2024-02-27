namespace FlightDataAnalysis.Acceptance.Urls
{
    /// <summary>
    /// Provides URLs for rest APIs.
    /// </summary>
    internal static class Urls
    {
        /// <summary>
        /// Provides URLs for flight.
        /// </summary>
        internal static class Flight
        {
            /// <summary>
            /// Provides URL for flight.
            /// </summary>
            internal const string FlightsUrl = Prefix;

            /// <summary>
            /// Provides URL for flight options.
            /// </summary>
            internal const string FlightOptionsUrl = $"{Prefix}/options";

            private const string Prefix = "api/v1/flights";

            /// <summary>
            /// Provides URL for flight by id.
            /// </summary>
            /// <param name="id">The flight id.</param>
            /// <returns>returns the flight url.</returns>
            internal static string FlightsById(string id) => $"{FlightsUrl}/{id}";

            /// <summary>
            /// Provides paged url.
            /// </summary>
            /// <param name="pageSize">The page size.</param>
            /// <param name="pageNumber">The page number.</param>
            /// <returns>returns the paged url.</returns>
            internal static string FlightPagedUrl(int pageNumber, int pageSize) => $"{Prefix}/paged?pageNumber={pageNumber}&pageSize={pageSize}";

        }

        /// <summary>
        /// Provides URLs for flight analysis.
        /// </summary>
        internal static class FlightAnalysis
        {
            /// <summary>
            /// Provides URL for flight analysis.
            /// </summary>
            internal const string FlightAnalysisUrl = "api/v1/flight-analysis";
        }
    }
}
