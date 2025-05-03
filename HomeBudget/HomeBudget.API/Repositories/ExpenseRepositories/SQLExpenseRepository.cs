using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.ExpenseRepositories
{
    public class SQLExpenseRepository : IRepository<Expense>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLExpenseRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Expense entity)
        {
            await dbContext.Expenses.AddAsync(entity);
        }

        public Task DeleteAsync(Guid id)
        {
            var existingEntity = dbContext.Expenses.FirstOrDefault(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Expense with id {id} not found.");
            }
            dbContext.Expenses.Remove(existingEntity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await dbContext.Expenses.ToListAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllIncludesAsync()
        {
            return await dbContext.Expenses
                .Include(i => i.Currency)
                .Include(i => i.ExpenseSorts)
                .ThenInclude(i => i.ExpenseSubsort)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .ToListAsync();
        }

        public Task<Expense> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Expense> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Expenses.FirstOrDefaultAsync(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Expense with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Expense> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.Expenses
                .Include(i => i.Currency)
                .Include(i => i.ExpenseSorts)
                .ThenInclude(i => i.ExpenseSubsort)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Expense with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Expense> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext
                .Expenses
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Expense with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Expense> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext
                .Expenses
                .Include(i => i.Currency)
                .Include(i => i.ExpenseSorts)
                .ThenInclude(i => i.ExpenseSubsort)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Expense with name {name} not found.");
            }
            return existingEntity;
        }

        public Task UpdateAsync(Expense entity)
        {
            dbContext.Expenses.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
