using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.ExpenseRepositories
{
    public class SQLExpenseSortRepository : IRepository<ExpenseSort>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLExpenseSortRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(ExpenseSort entity)
        {
            await dbContext.ExpenseSorts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            var existingEntity = dbContext.ExpenseSorts.FirstOrDefault(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"ExpenseSort with id {id} not found.");
            }
            dbContext.ExpenseSorts.Remove(existingEntity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseSort>> GetAllAsync()
        {
            return await dbContext.ExpenseSorts.ToListAsync();
        }

        public async Task<IEnumerable<ExpenseSort>> GetAllIncludesAsync()
        {
            return await dbContext
                .ExpenseSorts
                .Include(i => i.ExpenseSubsort)
                .Include(i => i.Expenses)
                .ToListAsync();
        }

        public Task<ExpenseSort> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseSort> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseSort> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.ExpenseSorts
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"ExpenseSort with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<ExpenseSort> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.ExpenseSorts
                .Include(i => i.ExpenseSubsort)
                .Include(i => i.Expenses)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"ExpenseSort with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<ExpenseSort> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.ExpenseSorts
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"ExpenseSort with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<ExpenseSort> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext.ExpenseSorts
                .Include(i => i.ExpenseSubsort)
                .Include(i => i.Expenses)
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"ExpenseSort with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(ExpenseSort entity)
        {
            dbContext.ExpenseSorts.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
