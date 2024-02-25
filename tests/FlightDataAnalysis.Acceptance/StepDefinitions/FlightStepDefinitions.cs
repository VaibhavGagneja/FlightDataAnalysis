namespace FlightDataAnalysis.Acceptance.StepDefinitions
{
    using System.Net;
    using System.Net.Http.Json;
    using FlightDataAnalysis.Acceptance.Constants;
    using TechTalk.SpecFlow.Assist;

    /// <summary>
    /// Steps definition files for flight.
    /// </summary>
    [Binding]
    internal class FlightStepDefinitions
    {
        private readonly HttpClient httpClient;
        private readonly ScenarioContext scenarioContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="FlightStepDefinitions"/> class.
        /// </summary>
        /// <param name="httpClient">The http client.</param>
        public FlightStepDefinitions(HttpClient httpClient, ScenarioContext scenarioContext)
        {
            this.httpClient = httpClient;
            this.scenarioContext = scenarioContext;
        }

        /// <summary>
        /// Calls the flight details api.
        /// </summary>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [When(@"When Flight details api is called")]
        public async Task WhenWhenFlightDetailsApiIsCalled()
        {
            var response = await this.httpClient.GetAsync(Urls.Urls.Flight.FlightsUrl);

            this.scenarioContext[TestConstants.HttpResponseScenarioKey] = response;
        }

        /// <summary>
        /// Asserts actual and expected flights.
        /// </summary>
        /// <param name="table">The expectation values in specflow table.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [Then(@"The system returns the flight details")]
        public async Task ThenTheSystemReturnsTheFlightDetails(Table table)
        {
            var actual = await ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey]).Content
                .ReadFromJsonAsync<IReadOnlyCollection<Business.Models.Flight>>();

            var expectations = table.CreateSet<Business.Models.Flight>().ToList();

            actual.Should().BeEquivalentTo(expectations);
        }

        /// <summary>
        /// Asserts actual and expected flights.
        /// </summary>
        /// <param name="table">The expectation values in specflow table.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [Then(@"The system returns the flight detail")]
        public async Task ThenTheSystemReturnsTheFlightDetail(Table table)
        {
            var actual = await ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey]).Content
                .ReadFromJsonAsync<Business.Models.Flight>();

            var expectations = table.CreateInstance<Business.Models.Flight>();

            actual.Should().BeEquivalentTo(expectations);
        }

        /// <summary>
        /// Asserts actual and expected flight options.
        /// </summary>
        /// <param name="table">The expectation values in specflow table.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [Then(@"The system returns the flight options")]
        public async Task ThenTheSystemReturnsTheFlightOptions(Table table)
        {
            var actual = await ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey]).Content
                .ReadFromJsonAsync<IReadOnlyCollection<Business.Models.FlightOption>>();

            var expectations = table.CreateSet<Business.Models.FlightOption>().ToList();

            actual.Should().BeEquivalentTo(expectations);
        }

        /// <summary>
        /// Calls the api to get flight details.
        /// </summary>
        /// <param name="flightId">The flight id.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [When(@"Flight details api is called by flight id ""([^""]*)""")]
        public async Task WhenFlightDetailsApiIsCalledByFlightId(string flightId)
        {
            var response = await this.httpClient.GetAsync(Urls.Urls.Flight.FlightsById(flightId));

            this.scenarioContext[TestConstants.HttpResponseScenarioKey] = response;
        }

        /// <summary>
        /// Asserts the expectation for entity not found.
        /// </summary>
        /// <param name="entity">The entity name.</param>
        /// <param name="id">The entity id.</param>
        [Then(@"The system returns the entity not found for entity ""([^""]*)"" and entity id ""([^""]*)""")]
        public void ThenTheSystemReturnsTheEntityNotFoundForEntityAndEntityId(string entity, string id)
        {
            ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey]).StatusCode.Should()
                .Be(HttpStatusCode.NotFound);
        }

        /// <summary>
        /// Calls flight options api.
        /// </summary>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [When(@"Flight options api is called")]
        public async Task WhenFlightOptionsApiIsCalled()
        {
            var response = await this.httpClient.GetAsync(Urls.Urls.Flight.FlightOptionsUrl);

            this.scenarioContext[TestConstants.HttpResponseScenarioKey] = response;
        }
    }
}
