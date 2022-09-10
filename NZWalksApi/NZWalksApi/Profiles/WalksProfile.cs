using AutoMapper;

namespace NZWalksApi.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.Dto.Walk>().ReverseMap();
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>().ReverseMap();
            CreateMap<Models.Dto.AddWalkRequest, Models.Domain.Walk>();
            CreateMap<Models.Dto.UpdateWalkRequest, Models.Domain.Walk>();
            CreateMap<Models.Domain.WalkDifficulty, Models.Dto.WalkDifficulty>().ReverseMap();
            CreateMap<Models.Dto.AddWalkDifficulty, Models.Domain.WalkDifficulty>();
            CreateMap<Models.Dto.UpdateWalkDifficultyRequest, Models.Domain.WalkDifficulty>();
        }
    }
}
