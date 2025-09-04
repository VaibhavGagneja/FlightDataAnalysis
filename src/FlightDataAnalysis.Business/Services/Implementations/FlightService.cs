namespace FlightDataAnalysis.Business.Services.Implementations
{
    using AutoMapper;
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Core.BusinessException;
    using FlightDataAnalysis.Data.Provider;

    /// <inheritdoc />
    public class FlightService : IFlightService
    {
        private readonly IDataProvider provider;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightService"/> class.
        /// </summary>
        /// <param name="provider">The data provider.</param>
        /// <param name="mapper">The mapper.</param>
        public FlightService(IDataProvider provider, IMapper mapper)
        {
            this.provider = provider;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<Flight> GetFlights()
        {
            var flights = this.provider.GetFlights();

            return this.mapper.Map<IReadOnlyCollection<Flight>>(flights);
        }

        /// <inheritdoc/>
        public Flight GetFlightById(int id)
        {
            var flight = this.provider.GetFlightById(id);

            if (flight == null)
            {
                throw new EntityNotFoundException(nameof(Flight), $"{id}");
            }

            return this.mapper.Map<Flight>(flight);
        }

        /// <inheritdoc/>
        public IReadOnlyCollection<FlightOption> GetFlightOptions()
        {
            var flights = this.provider.GetFlights();

            return this.mapper.Map<IReadOnlyCollection<FlightOption>>(flights);
        }

        /// <inheritdoc/>
        public PagedList<Flight> GetPaged(int pageNumber, int pageSize)
        {
            var results = this.provider.GetFlights();

            return this.mapper.Map<PagedList<Flight>>(PageListConverter.ToPagedList(results, pageNumber, pageSize));
        }
    }
}
