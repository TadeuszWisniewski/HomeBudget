using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Incomes;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.IncomeRepositories
{
    public class SQLIncomeSourceRepository : IRepository<IncomeSource>
    {
        private readonly HomeBudgetDbContext dbContext;
        public SQLIncomeSourceRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(IncomeSource entity)
        {
            await dbContext.IncomeSources.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public Task DeleteAsync(Guid id)
        {
            var existingEntity = dbContext.IncomeSources.FirstOrDefault(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSource with id {id} not found.");
            }
            dbContext.IncomeSources.Remove(existingEntity);
            return dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<IncomeSource>> GetAllAsync()
        {
            return await dbContext.IncomeSources.ToListAsync();
        }

        public async Task<IEnumerable<IncomeSource>> GetAllIncludesAsync()
        {
            return await dbContext.IncomeSources
                .Include(i => i.IncomeSubsource)
                .Include(i => i.Incomes)
                .ToListAsync();
        }

        public Task<IncomeSource> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IncomeSource> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IncomeSource> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.IncomeSources.FirstOrDefaultAsync(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSource with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<IncomeSource> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = 
                await dbContext.IncomeSources
                .Include(i => i.IncomeSubsource)
                .Include(i => i.Incomes)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSource with id {id} not found.");
            }
            return existingEntity;
        }

        public Task<IncomeSource> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IncomeSource> GetByNameIncludesAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IncomeSource entity)
        {
            dbContext.IncomeSources.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
