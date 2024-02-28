namespace FlightDataAnalysis.Controllers
{
    using System.Net.Mime;
    using Asp.Versioning;
    using FlightDataAnalysis.Business.Models;
    using FlightDataAnalysis.Business.Services;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides HTTP endpoints for flight analysis.
    /// </summary>
    [Route("api/v1/flight-analysis")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status500InternalServerError)]
    public class FlightAnalysisController : ControllerBase
    {
        private readonly IFlightAnalysisService flightAnalysisService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightAnalysisController"/> class.
        /// </summary>
        /// <param name="flightAnalysisService">The flight analysis service.</param>
        public FlightAnalysisController(IFlightAnalysisService flightAnalysisService)
        {
            this.flightAnalysisService = flightAnalysisService;
        }

        /// <summary>
        /// Gets the flight analysis report.
        /// </summary>
        /// <returns>returns an instance of <see cref="IReadOnlyCollection{FlightEntity}"/>.</returns>
        [HttpGet]
        [ProducesResponseType<IReadOnlyCollection<Flight>>(StatusCodes.Status200OK)]
        public IReadOnlyCollection<Flight> Get()
        {
            return this.flightAnalysisService.GetAnalysisReport();
        }
    }
}
