using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using HomeBudget.API.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests
{
    public class UserRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;
        public UserRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "UserTestDb")
                .Options;
        }
        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);

        [Fact]
        public async Task CreateAsync_ShouldCreateUser()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // user
            var user = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname",
                Name = "Test Name",
                Email = "Test Email",
            };
            // execute
            await userRepository.CreateAsync(user);
            // result
            var result = await db.User.FirstOrDefaultAsync(u => u.Name == "Test Name");
            // assert
            Assert.NotNull(result);
            Assert.Equal("Test Name", result.Name);

        }
        [Fact]
        public async Task GetById_ShouldReturnUser()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // user
            var user = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname",
                Name = "Test Name",
                Email = "Test Email",
            };
            // add user to db 
            await db.User.AddAsync(user);
            await db.SaveChangesAsync();
            // execute
            var result = await userRepository.GetByIdAsync(user.Id);
            // assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
        }
        [Fact]
        public async Task GetById_ShouldThrowKeyNotFoundException()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // execute & assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => userRepository.GetByIdAsync(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllUser()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // users
            var user1 = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname 1",
                Name = "Test Name 1",
                Email = "Test Email 1",
            };
            var user2 = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname 2",
                Name = "Test Name 2",
                Email = "Test Email 2",
            };
            // add to db
            await db.User.AddAsync(user1);
            await db.User.AddAsync(user2);
            await db.SaveChangesAsync();
            // execute
            var result = await userRepository.GetAllAsync();
            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateUser()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // user
            var user = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname",
                Name = "Test Name",
                Email = "Test Email",
            };
            // add to db
            await db.User.AddAsync(user);
            await db.SaveChangesAsync();
            // update user
            user.Surname = "Updated Surname";
            // execute
            await userRepository.UpdateAsync(user);
            // result
            var result = await db.User.FirstOrDefaultAsync(u => u.Id == user.Id);
            // assert
            Assert.NotNull(result);
            Assert.Equal("Updated Surname", result.Surname);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteUser()
        {
            // db context
            var db = CreateDbContext();
            // user repository
            var userRepository = new SQLUserRepository(db);
            // user
            var user = new User
            {
                Id = Guid.NewGuid(),
                Surname = "Test Surname",
                Name = "Test Name",
                Email = "Test Email",
            };
            // add to db
            await db.User.AddAsync(user);
            await db.SaveChangesAsync();
            // execute
            await userRepository.DeleteAsync(user.Id);
            // result
            var result = await db.User.FirstOrDefaultAsync(u => u.Id == user.Id);
            // assert
            Assert.Null(result);
        }
    }
}
