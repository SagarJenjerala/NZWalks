using AutoMapper;

namespace NZWalksApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Models.Dto.LoginRequest, Models.Domain.User>();
        }
    }
}
