namespace FlightDataAnalysis.Infrastructure.Initializer
{
    using FlightDataAnalysis.Data.Loader;
    using FlightDataAnalysis.Data.Models;
    using FlightDataAnalysis.Models.Configuration;
    using Microsoft.Extensions.Options;

    /// <inheritdoc />
    public class ServiceInitializer : IServiceInitializer
    {
        private readonly IDataLoader dataLoader;
        private readonly DataLoaderSetting setting;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceInitializer"/> class.
        /// </summary>
        /// <param name="dataLoader">The data loader.</param>
        /// <param name="setting">The data loader setting options.</param>
        public ServiceInitializer(IDataLoader dataLoader, IOptions<DataLoaderSetting> setting)
        {
            this.dataLoader = dataLoader;
            this.setting = setting.Value;
        }

        /// <inheritdoc/>
        public void Initialize()
        {
            this.dataLoader.Load(new DataLoaderConfig
            {
                Path = this.setting.FilePath,
                Delimiter = this.setting.Delimiter,
            });
        }
    }
}
