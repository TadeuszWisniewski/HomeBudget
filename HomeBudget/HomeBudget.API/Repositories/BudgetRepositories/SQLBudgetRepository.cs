using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Budgets;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.BudgetRepositories
{
    public class SQLBudgetRepository : IRepository<Budget>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLBudgetRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Budget entity)
        {
            await dbContext.Budgets.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.Budgets.FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Budget with id {id} not found.");
            }
            dbContext.Budgets.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            return await dbContext.Budgets
                .Include(b => b.BudgetType)
                .Include(b => b.BudgetDuration)
                .Include(b => b.ExpenseSubsorts)
                .ToListAsync();
        }

        public async Task<IEnumerable<Budget>> GetAllIncludesAsync()
        {
            return await dbContext.Budgets
                .Include(b => b.BudgetType)
                .Include(b => b.BudgetDuration)
                .Include(b => b.ExpenseSubsorts)
                .ToListAsync();
        }

        public Task<Budget> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Budget> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Budget> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Budgets.FirstOrDefaultAsync(b => b.Id == id);
            if(existingEntity == null)
            {
                throw new KeyNotFoundException($"Budget with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Budget> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.Budgets
                .Include(b => b.BudgetType)
                .Include(b => b.BudgetDuration)
                .Include(b => b.ExpenseSubsorts)
                .FirstOrDefaultAsync(b => b.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Budget with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Budget> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Budgets.FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Budget with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Budget> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext
                .Budgets
                .Include(b => b.BudgetType)
                .Include(b => b.BudgetDuration)
                .Include(b => b.ExpenseSubsorts)
                .FirstOrDefaultAsync(b => ((b.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Budget with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(Budget entity)
        {
            dbContext.Budgets.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
