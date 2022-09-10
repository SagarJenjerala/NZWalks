using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class WalkDifficutyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDbContext dbContext;

        public WalkDifficutyRepository(NZWalksDbContext nZWalksDbContext)
        {
            dbContext = nZWalksDbContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficultiAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await dbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await dbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid Id)
        {
            var result = await dbContext.WalkDifficulty.FindAsync(Id);
            if (result is null)
            {
                return null;
            }

            dbContext.WalkDifficulty.Remove(result);
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<WalkDifficulty> GetWalkDifficultByIdAsync(Guid Id)
        {
            var result = await dbContext.WalkDifficulty.FindAsync(Id);
            if (result is null)
                return null;

            return result;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetWalkDifficultiesAsync()
        {
            return await dbContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid Id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await dbContext.WalkDifficulty.FindAsync(Id);
            if (existingWalkDifficulty is null)
            {
                return null;
            }
            existingWalkDifficulty.Code = walkDifficulty.Code;

            await dbContext.SaveChangesAsync();

            return existingWalkDifficulty;
        }
    }
}
