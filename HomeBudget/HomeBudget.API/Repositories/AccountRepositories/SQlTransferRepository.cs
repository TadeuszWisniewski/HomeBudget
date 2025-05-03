using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.AccountRepositories
{
    public class SQlTransferRepository : IRepository<Transfer>
    {
        private readonly HomeBudgetDbContext dbContext;
        public SQlTransferRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(Transfer entity)
        {
            await dbContext.Transfers.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.Transfers.FirstOrDefaultAsync(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Transfer with id {id} not found.");
            }
            dbContext.Transfers.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Transfer>> GetAllAsync()
        {
            return await dbContext.Transfers.ToListAsync();
        }

        public async Task<IEnumerable<Transfer>> GetAllIncludesAsync()
        {
            return await dbContext.Transfers
                .Include(t => t.Accounts)
                .Include(t => t.Debt)
                .ToListAsync();
        }

        public Task<Transfer> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Transfer> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.Transfers.FirstOrDefaultAsync(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Transfer with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Transfer> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.Transfers
                .Include(t => t.Accounts)
                .Include(t => t.Debt)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Transfer with id {id} not found.");
            }
            return existingEntity;
        }

        public async Task<Transfer> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.Transfers.FirstOrDefaultAsync(t => t.Name == name);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Transfer with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<Transfer> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext
                .Transfers
                .Include(t => t.Accounts)
                .Include(t => t.Debt)
                .FirstOrDefaultAsync(t => t.Name == name);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Transfer with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(Transfer entity)
        {
            dbContext.Transfers.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
