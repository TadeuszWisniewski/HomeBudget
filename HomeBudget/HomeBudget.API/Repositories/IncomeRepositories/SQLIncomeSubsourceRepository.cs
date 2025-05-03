using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Incomes;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.IncomeRepositories
{
    public class SQLIncomeSubsourceRepository : IRepository<IncomeSubsource>
    {
        private readonly HomeBudgetDbContext dbContext;
        public SQLIncomeSubsourceRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(IncomeSubsource entity)
        {
            await dbContext.IncomeSubsource.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.IncomeSubsource.FirstOrDefaultAsync(i => i.Id == id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSubsource with id {id} not found.");
            }
            dbContext.IncomeSubsource.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<IncomeSubsource>> GetAllAsync()
        {
            return await dbContext.IncomeSubsource.ToListAsync();
        }

        public async Task<IEnumerable<IncomeSubsource>> GetAllIncludesAsync()
        {
            return await dbContext.IncomeSubsource
                .Include(i => i.IncomeSource)
                .ToListAsync();
        }

        public Task<IncomeSubsource> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IncomeSubsource> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IncomeSubsource> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.IncomeSubsource.FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSubsource with id {id} not found.");
            }

            return existingEntity;
        }

        public async Task<IncomeSubsource> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.IncomeSubsource
                .Include(i => i.IncomeSource)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSubsource with id {id} not found.");
            }

            return existingEntity;
        }

        public async Task<IncomeSubsource> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.IncomeSubsource.FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSubsource with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<IncomeSubsource> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext.IncomeSubsource.Include(i => i.IncomeSource).FirstOrDefaultAsync(i => ((i.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"IncomeSubsource with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task UpdateAsync(IncomeSubsource entity)
        {
            dbContext.IncomeSubsource.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
