namespace FlightDataAnalysis.Controllers
{
    using System.Net.Mime;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides API endpoints for flights.
    /// </summary>
    [Route("api/v1/flight")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public class FlightController : ControllerBase
    {
        /// <summary>
        /// Gets all flight details.
        /// </summary>
        /// <returns>returns <see cref="IReadOnlyCollection{Flight}"/>.</returns>
        [HttpGet]
        [ProducesResponseType<IReadOnlyCollection<Flight>>(StatusCodes.Status200OK)]
        public IReadOnlyCollection<Flight> Get()
        {
            return new List<Flight>();
        }

        /// <summary>
        /// Gets flight details by flight id.
        /// </summary>
        /// <param name="flightRequest">The flight request.</param>
        /// <returns>returns an instance <see cref="Flight"/>.</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<Flight>(StatusCodes.Status200OK)]
        [ProducesResponseType<Flight>(StatusCodes.Status200OK)]
        public Flight GetById(GetFlightRequest flightRequest)
        {
            return new Flight();
        }

        /// <summary>
        /// Gets flight options.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("options")]
        [ProducesResponseType<IReadOnlyCollection<FlightOption>>(StatusCodes.Status200OK)]
        public IReadOnlyCollection<FlightOption> GetOptions()
        {
            return new List<FlightOption>();
        }
    }
}
