using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.BudgetRepositories
{
    public class SQLBudgetTypeRepository : IRepository<BudgetType>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLBudgetTypeRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(BudgetType entity)
        {
            await dbContext.BudgetTypes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetTypes.FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetType with id {id} not found.");
            }
            dbContext.BudgetTypes.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BudgetType>> GetAllAsync()
        {
            return await dbContext.BudgetTypes.ToListAsync();
        }

        public async Task<IEnumerable<BudgetType>> GetAllIncludesAsync()
        {
            return await dbContext
                .BudgetTypes
                .Include(b => b.Budgets)
                .ToListAsync();
        }

        public Task<BudgetType> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<BudgetType> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<BudgetType> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetTypes.FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetType with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetType> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.BudgetTypes
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetType with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetType> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.BudgetTypes.FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetType with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<BudgetType> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext
                .BudgetTypes
                .Include(b => b.Budgets)
                .FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"BudgetType with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(BudgetType entity)
        {
            dbContext.BudgetTypes.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
