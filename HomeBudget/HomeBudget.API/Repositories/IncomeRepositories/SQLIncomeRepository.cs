
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Incomes;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.IncomeRepositories
{
    public class SQLIncomeRepository : IRepository<Income>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLIncomeRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Income entity)
        {
            await dbContext.Incomes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            var existingEntity = dbContext.Incomes.FirstOrDefault(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Income with id {id} not found.");
            }
            dbContext.Incomes.Remove(existingEntity);
            return dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            return await dbContext.Incomes.ToListAsync();
        }

        public async Task<IEnumerable<Income>> GetAllIncludesAsync()
        {
            return 
                await dbContext.Incomes
                .Include(i => i.Currency)
                .Include(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .ToListAsync();
        }

        public Task<Income> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Income> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Incomes.FirstOrDefaultAsync(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Income with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Income> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = 
                await dbContext
                .Incomes
                .Include(i => i.Currency)
                .Include(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Income with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Income> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Incomes.FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Income with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Income> GetByNameIncludesAsync(string name)
        {
            var existingEntity = 
                await dbContext
                .Incomes
                .Include(i => i.Currency)
                .Include(i => i.IncomeSources)
                .ThenInclude(i => i.IncomeSubsource)
                .Include(i => i.Accounts)
                .ThenInclude(i => i.Currency)
                .Include(i => i.Users)
                .ThenInclude(i => i.UserTypes)
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Income with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(Income entity)
        {
            dbContext.Incomes.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
