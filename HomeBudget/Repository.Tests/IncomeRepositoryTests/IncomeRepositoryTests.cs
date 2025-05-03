using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Currencies;
using HomeBudget.API.Models.Domain.Incomes;
using HomeBudget.API.Repositories.IncomeRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests.IncomeRepositoryTests
{
    public class IncomeRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;
        public IncomeRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "HomeBudgetTestDb")
                .Options;
        }
        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);
        [Fact]
        public async Task CreaeAsync_ShouldCreteIncome()
        {
            // Assert
            var db = CreateDbContext();
            var incomeRepository = new SQLIncomeRepository(db);
            var income = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income",
                Amount = 1000,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "USD",
                    Sign = "$"
                }
            };
            // Act
            await incomeRepository.CreateAsync(income);
            // Assert
            var result = await db.Incomes.FirstOrDefaultAsync(i => i.Name == "Test Income");
            Assert.NotNull(result);
            Assert.Equal("Test Income", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnIncome()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeRepository = new SQLIncomeRepository(db);
            var income = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income",
                Amount = 1000,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "USD",
                    Sign = "$"
                }
            };
            await db.Incomes.AddAsync(income);
            await db.SaveChangesAsync();
            // Act
            var result = await incomeRepository.GetByIdAsync(income.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Income", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundEcxception()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeRepository(db);
            var Income = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income",
                Amount = 100,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Currency",
                    Sign = "$"
                }
            };
            await db.Incomes.AddAsync(Income);
            await db.SaveChangesAsync();
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await repository.GetByIdAsync(Guid.NewGuid()));
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllIncomes()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeRepository(db);
            var income1 = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income1",
                Amount = 100,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Currency",
                    Sign = "$"
                }
            };
            var income2 = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income2",
                Amount = 100,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Currency",
                    Sign = "$"
                }
            };
            await db.AddRangeAsync(income1, income2);
            await db.SaveChangesAsync();
            // Act
            var result = await repository.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateIncome()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeRepository(db);
            var income = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income",
                Amount = 100,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Currency",
                    Sign = "$"
                }
            };
            await db.Incomes.AddAsync(income);
            await db.SaveChangesAsync();
            // Act
            income.Name = "Updated Name";
            await repository.UpdateAsync(income);
            // Assert
            var result = await db.Incomes.FirstOrDefaultAsync(i => i.Id == income.Id);
            Assert.NotNull(result);
            Assert.Equal("Updated Name", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteIncome()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeRepository(db);
            var income = new Income
            {
                Id = Guid.NewGuid(),
                Name = "Test Income",
                Amount = 100,
                Currency = new Currency
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Currnecy",
                    Sign = "$"
                }
            };
            await db.Incomes.AddAsync(income);
            await db.SaveChangesAsync();
            // Act
            await repository.DeleteAsync(income.Id);
            // Assert
            var result = await db.Incomes.FirstOrDefaultAsync(i => i.Id == income.Id);
            Assert.Null(result);
        }
    }
}
