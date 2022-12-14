using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();

        Task<Walk> GetAsync(Guid Id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk> UpdateAsync(Guid Id, Walk walk);

        Task<Walk> DeleteAsync(Guid Id);
    }
}
