namespace FlightDataAnalysis.Controllers
{
    using System.Net.Mime;
    using Asp.Versioning;
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Business.Services;
    using FlightDataAnalysis.Models.Requests;
    using FlightDataAnalysis.Models.Response;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides API endpoints for flights.
    /// </summary>
    [Route("api/v1/flights")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService flightService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightController"/> class.
        /// </summary>
        /// <param name="flightService">The flight service.</param>
        public FlightController(IFlightService flightService)
        {
            this.flightService = flightService;
        }

        /// <summary>
        /// Gets all flight details.
        /// </summary>
        /// <returns>returns <see cref="IReadOnlyCollection{Flight}"/>.</returns>
        [HttpGet]
        [ProducesResponseType<IReadOnlyCollection<Flight>>(StatusCodes.Status200OK)]
        public IReadOnlyCollection<Flight> Get()
        {
            return this.flightService.GetFlights();
        }

        /// <summary>
        /// Gets flight details by flight id.
        /// </summary>
        /// <param name="id">The flight id.</param>
        /// <returns>returns an instance <see cref="Flight"/>.</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<Flight>(StatusCodes.Status200OK)]
        [ProducesResponseType<BusinessErrorResponse>(StatusCodes.Status404NotFound)]
        public Flight GetById(int id)
        {
            return this.flightService.GetFlightById(id);
        }

        /// <summary>
        /// Gets flight options.
        /// </summary>
        /// <returns>returns <see cref="IReadOnlyCollection{FlightOption}"/>.</returns>
        [HttpGet]
        [Route("options")]
        [ProducesResponseType<IReadOnlyCollection<FlightOption>>(StatusCodes.Status200OK)]
        public IReadOnlyCollection<FlightOption> GetOptions()
        {
            return this.flightService.GetFlightOptions();
        }

        /// <summary>
        /// Gets flight options.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>returns <see cref="IReadOnlyCollection{FlightOption}"/>.</returns>
        [HttpGet]
        [Route("paged")]
        [ProducesResponseType<PagedList<Flight>>(StatusCodes.Status200OK)]
        public PagedList<Flight> GetPaged([FromQuery] PagedRequest request)
        {
            return this.flightService.GetPaged(request.PageNumber, request.PageSize);
        }
    }
}
