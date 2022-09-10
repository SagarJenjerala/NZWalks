using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalkRepository(NZWalksDbContext nDbContext)
        {
            dbContext = nDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid Id)
        {
            var existingWalk = await dbContext.Walks.FindAsync(Id);
            if (existingWalk is null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await dbContext.Walks.Include("Region").Include("WalkDifficulty").ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid Id)
        {
            var walk = await dbContext.Walks
                  .Include("Region")
                  .Include("WalkDifficulty")
                  .FirstOrDefaultAsync(x => x.Id == Id);
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid Id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FindAsync(Id);
            if (existingWalk is null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
