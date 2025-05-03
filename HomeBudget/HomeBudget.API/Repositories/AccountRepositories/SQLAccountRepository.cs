using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.AccountRepositories
{
    public class SQLAccountRepository : IRepository<Account>
    {
        private readonly HomeBudgetDbContext dbContext;
        public SQLAccountRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Account entity)
        {
            await dbContext.Accounts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Account with id {id} not found.");
            }
            dbContext.Accounts.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        public async Task<IEnumerable<Account>> GetAllIncludesAsync()
        {
            return await dbContext.Accounts
                .Include(a => a.Expenses)
                .Include(a => a.Incomes)
                .Include(a => a.Transfers)
                .Include(a => a.Users)
                .Include(a => a.Debts)
                .Include(a => a.Currency)
                .ToListAsync();
        }

        public Task<Account> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            var existingExtity = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Id == id);
            if (existingExtity == null)
            {
                throw new KeyNotFoundException($"Account with id {id} not found.");
            }
            return existingExtity;
        }

        public async Task<Account> GetByIdIncludesAsync(Guid id)
        {
            var existingExtity = await dbContext.Accounts
                .Include(a => a.Expenses)
                .Include(a => a.Incomes)
                .Include(a => a.Transfers)
                .Include(a => a.Users)
                .Include(a => a.Debts)
                .Include(a => a.Currency)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (existingExtity == null)
            {
                throw new KeyNotFoundException($"Account with id {id} not found.");
            }
            return existingExtity;
        }

        public async Task<Account> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Accounts.FirstOrDefaultAsync(a => a.Name == name);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Account with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Account> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext.Accounts
                .Include(a => a.Expenses)
                .Include(a => a.Incomes)
                .Include(a => a.Transfers)
                .Include(a => a.Users)
                .Include(a => a.Debts)
                .Include(a => a.Currency)
                .FirstOrDefaultAsync(a => a.Name == name);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Account with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(Account entity)
        {
            dbContext.Accounts.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
