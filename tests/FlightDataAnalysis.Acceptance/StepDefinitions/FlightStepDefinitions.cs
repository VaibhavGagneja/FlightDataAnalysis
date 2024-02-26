using FlightDataAnalysis.Business.Models;

namespace FlightDataAnalysis.Acceptance.StepDefinitions
{
    using System.Net;
    using System.Net.Http.Json;
    using FlightDataAnalysis.Acceptance.Constants;
    using FlightDataAnalysis.Models.Response;
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
        /// <param name="scenarioContext">The scenario context.</param>
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
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [Then(@"The system returns the entity not found for entity ""([^""]*)"" and entity id ""([^""]*)""")]
        public async Task ThenTheSystemReturnsTheEntityNotFoundForEntityAndEntityId(string entity, string id)
        {
            ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey]).StatusCode.Should()
                .Be(HttpStatusCode.NotFound);

            var errorResponse = await ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey])
                .Content.ReadFromJsonAsync<BusinessErrorResponse>();

            errorResponse.Should().BeEquivalentTo(new BusinessErrorResponse
            {
                StatusCode = (int)HttpStatusCode.NotFound, ErrorMessage = $"{entity} not found by {id}",
            });
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

        /// <summary>
        /// Calls flight paged api.
        /// </summary>
        /// <param name="number">Page number.</param>
        /// <param name="size">Page size.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [When(@"Flight paged api is called by page size ""([^""]*)"" page number ""([^""]*)""")]
        public async Task WhenFlightPagedApiIsCalledByPageSizePageNumber(string size, string number)
        {
            var response = await this.httpClient.GetAsync(Urls.Urls.Flight.FlightPagedUrl(int.Parse(number), int.Parse(size)));

            this.scenarioContext[TestConstants.HttpResponseScenarioKey] = response;
        }

        /// <summary>
        /// Validates paged response.
        /// </summary>
        /// <param name="totalPage">Total pages.</param>
        /// <param name="totalCount">Total items count.</param>
        /// <param name="pageSize">Page size.</param>
        /// <param name="table">The items.</param>
        /// <returns>returns an instance of <see cref="Task"/>.</returns>
        [Then(@"The system returns the flight details total pages ""([^""]*)"" total count ""([^""]*)"" and page size ""([^""]*)""")]
        public async Task ThenTheSystemReturnsTheFlightDetailsTotalPagesTotalCountAndPageSize(
            string totalPage,
            string totalCount,
            string pageSize,
            Table table)
        {
            var response = await ((HttpResponseMessage)this.scenarioContext[TestConstants.HttpResponseScenarioKey])
                .Content.ReadFromJsonAsync<PagedList<Flight>>();

            var expected = new PagedList<Flight>()
            {
                PageSize = int.Parse(pageSize),
                TotalCount = int.Parse(totalCount),
                TotalPagesCount = int.Parse(totalPage),
                Items = table.CreateSet<Flight>().ToList(),
            };

            expected.Should().BeEquivalentTo(response);
        }
    }
}
