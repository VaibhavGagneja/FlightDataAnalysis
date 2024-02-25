namespace FlightDataAnalysis.Acceptance.StepDefinitions
{
    using FlightDataAnalysis.Acceptance.Constants;

    /// <summary>
    /// Step definition file for flight analysis step definition.
    /// </summary>
    [Binding]
    internal sealed class FlightAnalysisStepDefinition
    {
        private readonly HttpClient httpClient;
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightAnalysisStepDefinition"/> class.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        /// <param name="scenarioContext">The scenario context.</param>
        public FlightAnalysisStepDefinition(HttpClient httpClient, ScenarioContext scenarioContext)
        {
            this.httpClient = httpClient;
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Calls the flight analysis api.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [When(@"Flight analysis api is called")]
        public async Task WhenFlightAnalysisApiIsCalled()
        {
            var response = await this.httpClient.GetAsync(Urls.Urls.FlightAnalysis.FlightAnalysisUrl);

            this.scenarioContext[TestConstants.HttpResponseScenarioKey] = response;
        }
    }
}
