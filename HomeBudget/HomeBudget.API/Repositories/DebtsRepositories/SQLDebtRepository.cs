using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Debts;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.DebtsRepositories
{
    public class SQLDebtRepository : IRepository<Debt>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLDebtRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(Debt entity)
        {
            await dbContext.Debts.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.Debts.FirstOrDefaultAsync(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Debt with id {id} not found.");
            }
            dbContext.Debts.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Debt>> GetAllAsync()
        {
            return await dbContext.Debts.ToListAsync();
        }

        public async Task<IEnumerable<Debt>> GetAllIncludesAsync()
        {
            return 
                await dbContext
                .Debts
                .Include(i => i.Currency)
                .Include(i => i.Account)
                .Include(i => i.Users)
                .Include(i => i.Transfers)
                .ToListAsync();
        }

        public Task<Debt> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Debt> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Debt> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Debts.FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Debt with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Debt> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.Debts
                .Include(i => i.Currency)
                .Include(i => i.Account)
                .Include(i => i.Users)
                .Include (i => i.Transfers)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Debt with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Debt> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Debts.FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Debt with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Debt> GetByNameIncludesAsync(string name)
        {
            var existingEntity = 
                await dbContext
                .Debts
                .Include(i => i.Currency)
                .Include(i => i.Account)
                .Include(i => i.Users)  
                .Include(i => i.Transfers)
                .FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Debt with name {name} not found.");
            }
            return existingEntity;
        }

        public Task UpdateAsync(Debt entity)
        {
            dbContext.Debts.Update(entity);
            return dbContext.SaveChangesAsync();
        }
    }
}
