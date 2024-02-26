using FlightDataAnalysis.Business.Models;

namespace FlightDataAnalysis.Business.Services
{
    /// <summary>
    /// Page list converters.
    /// </summary>
    internal static class PageListConverter
    {
        /// <summary>
        /// Converts source to page list.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>returns an instance of <see cref="PagedList{T}"/>.</returns>
        public static PagedList<T> ToPagedList<T>(IReadOnlyCollection<T> source, int pageNumber, int pageSize)
            where T : class
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>
            {
                Items = items,
                PageSize = pageSize,
                TotalCount = count,
                TotalPagesCount = (int)Math.Ceiling(count / (double)pageSize),
            };
        }
    }
}
