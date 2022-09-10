using AutoMapper;

namespace NZWalksApi.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.Dto.Region>().ReverseMap();
            //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
        }
    }
}
