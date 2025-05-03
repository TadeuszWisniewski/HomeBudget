using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Expenses;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.ExpenseRepositories
{
    public class SQLExpenseSubSortRepository : IRepository<ExpenseSubsort>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLExpenseSubSortRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(ExpenseSubsort entity)
        {
            await dbContext.ExpenseSubsorts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var exisitngEntity = await dbContext.ExpenseSubsorts.FirstOrDefaultAsync(e => e.Id == id);
            if(exisitngEntity == null)
            {
                throw new KeyNotFoundException($"Expense Sunsource with id {id} not found.");
            }
            dbContext.Remove(exisitngEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseSubsort>> GetAllAsync()
        {
            return await dbContext.ExpenseSubsorts.ToListAsync();
        }

        public async Task<IEnumerable<ExpenseSubsort>> GetAllIncludesAsync()
        {
            return await dbContext.ExpenseSubsorts.Include(e => e.ExpenseSort).ToListAsync();
        }

        public Task<ExpenseSubsort> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<ExpenseSubsort> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<ExpenseSubsort> GetByIdAsync(Guid id)
        {
            var exisitngEntity = await dbContext.ExpenseSubsorts.FirstOrDefaultAsync(e => e.Id == id);
            if(exisitngEntity == null)
            {
                throw new KeyNotFoundException($"Expense Subsource with id {id} not found.");
            }
            return exisitngEntity;
        }

        public async Task<ExpenseSubsort> GetByIdIncludesAsync(Guid id)
        {
            var exisitngEntity = 
                await dbContext
                .ExpenseSubsorts
                .Include(e => e.ExpenseSort)
                .Include(e => e.Budgets)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (exisitngEntity == null)
            {
                throw new KeyNotFoundException($"Expense Subsource with id {id} not found.");
            }
            return exisitngEntity;
        }

        public async Task<ExpenseSubsort> GetByNameAsync(string name)
        {
            var exisitngEntity =
                await dbContext
                .ExpenseSubsorts
                .FirstOrDefaultAsync(e => ((e.Name).Trim()).Equals(name.Trim()));

            if (exisitngEntity == null)
            {
                throw new KeyNotFoundException($"Expense Subsource with name {name} not found.");
            }
            return exisitngEntity;
        }

        public async Task<ExpenseSubsort> GetByNameIncludesAsync(string name)
        {
            var exisitngEntity =
                await dbContext
                .ExpenseSubsorts
                .Include(e => e.ExpenseSort)
                .Include(e => e.Budgets)
                .FirstOrDefaultAsync(e => ((e.Name).Trim()).Equals(name.Trim()));

            if (exisitngEntity == null)
            {
                throw new KeyNotFoundException($"Expense Subsource with name {name} not found.");
            }
            return exisitngEntity;
        }

        public async Task UpdateAsync(ExpenseSubsort entity)
        {
            dbContext.ExpenseSubsorts.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
