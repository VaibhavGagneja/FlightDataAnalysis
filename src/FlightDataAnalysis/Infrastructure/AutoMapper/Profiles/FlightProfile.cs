namespace FlightDataAnalysis.Infrastructure.AutoMapper.Profiles
{
    using FlightDataAnalysis.Business.Models;
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
            this.CreateMap<PagedList<FlightEntity>, PagedList<Flight>>()
                .ForMember(x => x.PageSize, o => o.MapFrom(x => x.PageSize))
                .ForMember(x => x.TotalCount, o => o.MapFrom(x => x.TotalCount))
                .ForMember(x => x.TotalPagesCount, o => o.MapFrom(x => x.TotalPagesCount))
                .ForMember(x => x.Items, o => o.MapFrom(x => x.Items));
        }
    }
}
