using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using HomeBudget.API.Repositories;
using HomeBudget.API.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests
{
    public class UserTypesRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;

        public UserTypesRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "UserTypesTestDb")
                .Options;
        }

        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);

        [Fact]
        public async Task CreateAsync_ShouldCreateUserType()
        {
            // db context
            var db = CreateDbContext();

            // user type repository
            var userTypeRepository = new SQLUserTypesRepository(db);

            // user type
            var userType = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type"
            };

            // execute
            await userTypeRepository.CreateAsync(userType);

            // result
            var restult = await db.UserTypes.FirstOrDefaultAsync(u => u.Name == "Test User Type");

            // assert
            Assert.NotNull(restult);
            Assert.Equal("Test User Type", restult.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnUserType()
        {
            // db context
            var db = CreateDbContext();
            // user type repository
            var userTypeRepository = new SQLUserTypesRepository(db);
            // user types
            var userType1 = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type 1"
            };
            // add to db
            await db.UserTypes.AddAsync(userType1);
            await db.SaveChangesAsync();
            // execute
            var result = await userTypeRepository.GetByIdAsync(userType1.Id);
            // assert
            Assert.NotNull(result);
            Assert.Equal("Test User Type 1", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFountException()
        {
            //db context
            var db = CreateDbContext();
            // user type repository
            var repository = new SQLUserTypesRepository(db);

            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                // execute
                await repository.GetByIdAsync(Guid.NewGuid());
            });
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUserTypes()
        {
            // db context
            var db = CreateDbContext();
            // user type repository
            var userTypeRepository = new SQLUserTypesRepository(db);
            // user types
            var userType1 = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type 1"
            };
            var userType2 = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type 2"
            };
            // add to db
            await db.UserTypes.AddRangeAsync(userType1, userType2);
            await db.SaveChangesAsync();
            // execute
            var result = await userTypeRepository.GetAllAsync();
            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateUserType()
        {
            // db context
            var db = CreateDbContext();
            // user type repository
            var userTypeRepository = new SQLUserTypesRepository(db);
            // user types
            var userType1 = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type 1"
            };
            // add to db
            await db.UserTypes.AddAsync(userType1);
            await db.SaveChangesAsync();
            // update
            userType1.Name = "Updated User Type 1";
            // execute
            await userTypeRepository.UpdateAsync(userType1);
            // result
            var result = await db.UserTypes.FirstOrDefaultAsync(u => u.Id == userType1.Id);
            // assert
            Assert.NotNull(result);
            Assert.Equal("Updated User Type 1", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteUserType()
        {
            // db context
            var db = CreateDbContext();
            // user type repository
            var userTypeRepository = new SQLUserTypesRepository(db);
            // user types
            var userType1 = new UserType
            {
                Id = Guid.NewGuid(),
                Name = "Test User Type 1"
            };
            // add to db
            await db.UserTypes.AddAsync(userType1);
            await db.SaveChangesAsync();
            // execute
            await userTypeRepository.DeleteAsync(userType1.Id);
            // result
            var result = db.UserTypes.Find(userType1.Id);
            // assert
            Assert.Null(result);
        }
    }
}
