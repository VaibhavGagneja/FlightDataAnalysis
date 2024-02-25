namespace FlightDataAnalysis.Acceptance
{
    using BoDi;

    /// <summary>
    /// Initializes the test server.
    /// </summary>
    [Binding]
    internal class SetupHooks
    {
        private static CustomWebApplicationFactory<Program> factory;

        /// <summary>
        /// Starts the test server.
        /// </summary>
        /// <param name="objectContainer">The object container.</param>
        [BeforeTestRun]
        internal static void StartServer(IObjectContainer objectContainer)
        {
            factory = new CustomWebApplicationFactory<Program>();

            var client = factory.Server.CreateClient();

            objectContainer.RegisterInstanceAs(client);
        }

        /// <summary>
        /// Stops the server and disposes the host.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [AfterTestRun]
        internal static async Task StopServer()
        {
            await factory.DisposeAsync();
        }
    }
}
