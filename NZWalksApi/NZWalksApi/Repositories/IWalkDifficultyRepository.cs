using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>> GetWalkDifficultiesAsync();

        Task<WalkDifficulty> GetWalkDifficultByIdAsync(Guid Id);

        Task<WalkDifficulty> AddWalkDifficultiAsync(WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid Id, WalkDifficulty walkDifficulty);

        Task<WalkDifficulty> DeleteAsync(Guid Id);
    }
}
