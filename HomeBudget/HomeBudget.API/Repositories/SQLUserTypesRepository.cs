using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories
{
    public class SQLUserTypesRepository : IRepository<UserType>
    {
        private readonly HomeBudgetDbContext dbContext;

        public SQLUserTypesRepository(HomeBudgetDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(UserType entity)
        {
            await dbContext.UserTypes.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var existingEntity = await dbContext.UserTypes.FirstOrDefaultAsync(u => u.Id == id);

            if(existingEntity == null)
            {
                throw new KeyNotFoundException($"UserType with id {id} not found.");
            }

            dbContext.UserTypes.Remove(existingEntity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            return await dbContext.UserTypes.Include(u => u.Users).ToListAsync();
        }

        public async Task<UserType> GetByIdAsync(Guid id)
        {
            var existingEntity = await dbContext.UserTypes.FirstOrDefaultAsync(u => u.Id == id);

            if(existingEntity == null)
            {
                throw new KeyNotFoundException($"UserType with id {id} not found.");
            }

            return existingEntity;
        }

        public async Task UpdateAsync(UserType entity)
        {
            dbContext.UserTypes.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
