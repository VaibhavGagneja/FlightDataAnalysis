using Newtonsoft.Json;

namespace FlightDataAnalysis.Business.Models
{
    /// <summary>
    /// The paged list model.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class PagedList<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets total count.
        /// </summary>
        [JsonProperty(PropertyName = "totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// Gets or sets total page count.
        /// </summary>
        [JsonProperty(PropertyName = "totalPagesCount")]
        public int TotalPagesCount { get; set; }

        /// <summary>
        /// Gets or sets page size.
        /// </summary>
        [JsonProperty(PropertyName = "pageSize")]
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets items.
        /// </summary>
        [JsonProperty(PropertyName = "items")]
        public IReadOnlyCollection<T> Items { get; set; }
    }
}
