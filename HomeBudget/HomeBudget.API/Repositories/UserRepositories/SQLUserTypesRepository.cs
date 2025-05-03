using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Repositories.UserRepositories
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
            return await dbContext.UserTypes.ToListAsync();
        }

        public async Task<IEnumerable<UserType>> GetAllIncludesAsync()
        {
            return await dbContext.UserTypes
                .Include(u => u.Users)
                .ToListAsync();
        }

        public Task<UserType> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserType> GetByEmailIncludesAsync(string email)
        {
            throw new NotImplementedException();
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

        public async Task<UserType> GetByIdIncludesAsync(Guid id)
        {
            var existingEntity = await dbContext.UserTypes.Include(u => u.Users).FirstOrDefaultAsync(u => u.Id == id);

            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"UserType with id {id} not found.");
            }

            return existingEntity;
        }

        public async Task<UserType> GetByNameAsync(string name)
        {
            var existingEntity = await dbContext.UserTypes.FirstOrDefaultAsync(u => ((u.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"UserType with name {name} not found.");
            }
            return existingEntity;
        }

        public async Task<UserType> GetByNameIncludesAsync(string name)
        {
            var existingEntity = await dbContext.UserTypes.Include(u => u.Users).FirstOrDefaultAsync(u => ((u.Name).Trim()).Equals(name.Trim()));
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"UserType with name {name} not found.");
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
