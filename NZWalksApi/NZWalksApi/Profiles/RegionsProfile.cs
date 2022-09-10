using AutoMapper;

namespace NZWalksApi.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.Dto.Region>().ReverseMap();
            CreateMap<Models.Dto.Region, Models.Domain.Region>();
            CreateMap<Models.Dto.AddRegionRequest, Models.Domain.Region>();
            CreateMap<Models.Dto.UpdateRegionRequest, Models.Domain.Region>();
            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}
