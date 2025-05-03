using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Incomes;
using HomeBudget.API.Repositories.IncomeRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests.IncomeRepositoryTests
{
    public class IncomeSubsourceRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;
        public IncomeSubsourceRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "HomeBudgetTestDb")
                .Options;
        }
        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);
        [Fact]
        public async Task CreateAsync_ShouldCreateIncomeSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var incomeSubsource = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource"
            };
            // Act
            await incomeSubsourceRepository.CreateAsync(incomeSubsource);
            // Assert
            var result = await db.IncomeSubsource.FirstOrDefaultAsync(i => i.Name == "Test Income Subsource");
            Assert.NotNull(result);
            Assert.Equal("Test Income Subsource", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnIncomeSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var incomeSubsource = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource"
            };
            await db.IncomeSubsource.AddAsync(incomeSubsource);
            await db.SaveChangesAsync();
            // Act
            var result = await incomeSubsourceRepository.GetByIdAsync(incomeSubsource.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Income Subsource", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundException()
        {             
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var nonExistentId = Guid.NewGuid();
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => incomeSubsourceRepository.GetByIdAsync(nonExistentId));
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllIncomeSubsources()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var incomeSubsource1 = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource 1"
            };
            var incomeSubsource2 = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource 2"
            };
            await db.IncomeSubsource.AddRangeAsync(incomeSubsource1, incomeSubsource2);
            await db.SaveChangesAsync();
            // Act
            var result = await incomeSubsourceRepository.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateIncomeSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var incomeSubsource = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource"
            };
            await db.IncomeSubsource.AddAsync(incomeSubsource);
            await db.SaveChangesAsync();
            // Act
            incomeSubsource.Name = "Updated Income Subsource";
            await incomeSubsourceRepository.UpdateAsync(incomeSubsource);
            // Assert
            var result = await db.IncomeSubsource.FirstOrDefaultAsync(i => i.Id == incomeSubsource.Id);
            Assert.NotNull(result);
            Assert.Equal("Updated Income Subsource", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteIncomeSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSubsourceRepository = new SQLIncomeSubsourceRepository(db);
            var incomeSubsource = new IncomeSubsource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Subsource"
            };
            await db.IncomeSubsource.AddAsync(incomeSubsource);
            await db.SaveChangesAsync();
            // Act
            await incomeSubsourceRepository.DeleteAsync(incomeSubsource.Id);
            // Assert
            var result = await db.IncomeSubsource.FirstOrDefaultAsync(i => i.Id == incomeSubsource.Id);
            Assert.Null(result);
        }
    }
}
