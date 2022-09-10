using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid guid);
        Task<Region> AddAsync(Region region);
        Task<Region> DeleteAsync(Guid Id);
        Task<Region> UpdateAsync(Guid Id, Region region);
    }
}
