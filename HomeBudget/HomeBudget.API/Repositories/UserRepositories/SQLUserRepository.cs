using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.UserRepositories
{
    public class SQLUserRepository : IRepository<User>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLUserRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(User entity)
        {
            await dbContext.User.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            dbContext.User.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.User.ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllIncludesAsync()
        {
            return 
                await dbContext.User
                .Include(u => u.Accounts)
                .ThenInclude(a => a.Transfers)
                .Include(u => u.Expenses)
                .ThenInclude(e => e.ExpenseSorts)
                .ThenInclude(e => e.ExpenseSubsort)
                .Include(u => u.Incomes)
                .ThenInclude(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(u => u.UserTypes)
                .Include(u => u.Debts)
                .Include(u => u.CoOperator)
                .ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var existingEntity = await dbContext.User.FirstOrDefaultAsync(u => ((u.Email).Trim()).Equals(email.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }
            return existingEntity;
        }

        public async Task<User> GetByEmailIncludesAsync(string email)
        {
            var existingEntity = 
                await dbContext
                .User
                .Include(u => u.Accounts)
                .ThenInclude(a => a.Transfers)
                .Include(u => u.Expenses)
                .ThenInclude(e => e.ExpenseSorts)
                .ThenInclude(e => e.ExpenseSubsort)
                .Include(u => u.Incomes)
                .ThenInclude(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(u => u.UserTypes)
                .Include(u => u.Debts)
                .Include(u => u.CoOperator)
                .FirstOrDefaultAsync(u => ((u.Email).Trim()).Equals(email.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with email {email} not found.");
            }
            return existingEntity;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<User> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = 
                await dbContext
                .User
                .Include(u => u.Accounts)
                .ThenInclude(a => a.Transfers)
                .Include(u => u.Expenses)
                .ThenInclude(e => e.ExpenseSorts)
                .ThenInclude(e => e.ExpenseSubsort)
                .Include(u => u.Incomes)
                .ThenInclude(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(u => u.UserTypes)
                .Include(u => u.Debts)
                .Include(u => u.CoOperator)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<User> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.User.FirstOrDefaultAsync(u => ((u.Surname).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<User> GetByNameIncludesAsync(string name)
        {
            var existingEntity = 
                await dbContext
                .User
                .Include(u => u.Accounts)
                .ThenInclude(a => a.Transfers)
                .Include(u => u.Expenses)
                .ThenInclude(e => e.ExpenseSorts)
                .ThenInclude(e => e.ExpenseSubsort)
                .Include(u => u.Incomes)
                .ThenInclude(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(u => u.UserTypes)
                .Include(u => u.Debts)
                .Include(u => u.CoOperator)
                .FirstOrDefaultAsync(u => ((u.Surname).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"User with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(User entity)
        {
            dbContext.User.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
