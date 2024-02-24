namespace FlightDataAnalysis.Controllers
{
    using System.Net.Mime;
    using Asp.Versioning;
    using FlightDataAnalysis.Models.Request;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides API endpoints for flights.
    /// </summary>
    [Route("api/v1/flight")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class FlightController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
        }

        /// <summary>
        /// Gets flight details by flight id.
        /// </summary>
        /// <param name="flightRequest">The flight request.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public string GetById(GetFlightRequest flightRequest)
        {
            return $"{flightRequest.Id}";
        }

        [HttpGet]
        [Route("options")]
        public string GetOptions()
        {
            return "options";
        }
    }
}
