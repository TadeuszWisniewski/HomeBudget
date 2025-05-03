using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.BudgetRepositories
{
    public class SQLBudgetDurationRepository : IRepository<BudgetDuration>
    {
        private readonly HomeBudgetDbContext dbContext;
        public SQLBudgetDurationRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(BudgetDuration entity)
        {
            await dbContext.BudgetDurations.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetDurations.FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetDuration with id {id} not found.");
            }
            dbContext.BudgetDurations.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<BudgetDuration>> GetAllAsync()
        {
            return await dbContext.BudgetDurations.ToListAsync();
        }

        public async Task<IEnumerable<BudgetDuration>> GetAllIncludesAsync()
        {
            return await dbContext.BudgetDurations
                .Include(b => b.Budgets)
                .ToListAsync();
        }

        public Task<BudgetDuration> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetDuration> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<BudgetDuration> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetDurations.FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetDuration with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetDuration> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetDurations
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetDuration with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetDuration> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext
                .BudgetDurations
                .FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetDuration with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetDuration> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext
                .BudgetDurations
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetDuration with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(BudgetDuration entity)
        {
            dbContext.BudgetDurations.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
