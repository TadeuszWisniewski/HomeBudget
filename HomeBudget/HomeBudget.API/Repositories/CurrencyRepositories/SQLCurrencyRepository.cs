using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Currencies;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.CurrencyRepositories
{
    public class SQLCurrencyRepository : IRepository<Currency>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLCurrencyRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Currency entity)
        {
            await dbContext.Currency.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.Currency.FirstOrDefaultAsync(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Currency with id {id} not found.");
            }
            dbContext.Currency.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            return await dbContext.Currency.ToListAsync();
        }

        public Task<IEnumerable<Currency>> GetAllIncludesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Currency> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Currency.FirstOrDefaultAsync(c => c.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Currency with id {id} not found.");
            }
            return existingEntity;
        }

        public Task<Currency> GetByIdIncludesAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Currency> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Currency.FirstOrDefaultAsync(c => ((c.Sign).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Currency with name {name} not found.");
            }
            return existingEntity;
        }

        public Task<Currency> GetByNameIncludesAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Currency entity)
        {
            dbContext.Currency.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
