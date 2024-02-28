using System.ComponentModel;

namespace FlightDataAnalysis.Models.Requests
{
    /// <summary>
    /// Paged request model.
    /// </summary>
    public class PagedRequest
    {
        /// <summary>
        /// Gets or sets page number.
        /// </summary>
        [JsonProperty(PropertyName = "pageNumber", DefaultValueHandling = DefaultValueHandling.Populate)]
        public int PageNumber { get; set; } = 1;

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", DefaultValueHandling = DefaultValueHandling.Populate)]
        public int PageSize { get; set; } = 10;
    }
}
