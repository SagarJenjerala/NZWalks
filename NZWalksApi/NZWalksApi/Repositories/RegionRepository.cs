using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public RegionRepository(NZWalksDbContext walksDbContext)
        {
            _dbContext = walksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await _dbContext.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await GetAsync(Id);
            if (region is null)
            {
                return null;
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid guid)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == guid);
            return region;
        }

        public async Task<Region> UpdateAsync(Guid Id, Region region)
        {
            var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingRegion is null)
            {
                return null;
            }

            existingRegion.Area = region.Area;
            existingRegion.Population = region.Population;
            existingRegion.Code = region.Code;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Name = region.Name;

            await _dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
