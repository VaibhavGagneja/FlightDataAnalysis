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
        [DefaultValue(1)]
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        [JsonProperty(PropertyName = "pageSize", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(10)]
        public int PageSize { get; set; }
    }
}
