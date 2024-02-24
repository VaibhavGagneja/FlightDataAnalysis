namespace FlightDataAnalysis.Controllers
{
    using System.Net.Mime;
    using Asp.Versioning;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Provides HTTP endpoints for flight analysis.
    /// </summary>
    [Route("api/v1/flightAnalysis")]
    [ApiController]
    [ApiVersion("1.0")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public class FlightAnalysisController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "";
        }
    }
}
