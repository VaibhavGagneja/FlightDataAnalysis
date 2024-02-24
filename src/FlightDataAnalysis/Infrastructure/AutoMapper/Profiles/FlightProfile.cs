using FlightDataAnalysis.Business.Models;

namespace FlightDataAnalysis.Infrastructure.AutoMapper.Profiles
{
    using FlightDataAnalysis.Data.Models;

    /// <summary>
    /// Auto mapper Profile for flight and dto.
    /// </summary>
    public class FlightProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlightProfile"/> class.
        /// </summary>
        public FlightProfile()
        {
            this.CreateMap<FlightEntity, Flight>();
            this.CreateMap<FlightEntity, FlightOption>();
        }
    }
}
