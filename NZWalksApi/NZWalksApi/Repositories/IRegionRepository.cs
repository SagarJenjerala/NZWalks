using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public interface IRegionRepository
    {
       Task<IEnumerable<Region>> GetAllAsync();
    }
}
