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
    public class IncomeSourceRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;
        public IncomeSourceRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "HomeBudgetTestDb")
                .Options;
        }
        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);
        [Fact]
        public async Task CreateAsync_ShouldCreateIncomeSource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSourceRepository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Source"
            };
            // Act
            await incomeSourceRepository.CreateAsync(incomeSource);
            // Assert
            var result = await db.IncomeSources.FirstOrDefaultAsync(i => i.Name == "Test Income Source");
            Assert.NotNull(result);
            Assert.Equal("Test Income Source", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnIncomeSource()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSourceRepository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Source",
                IncomeSubsource = 
                    new IncomeSubsource
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Income Subsource"
                    }
            };
            await db.IncomeSources.AddAsync(incomeSource);
            await db.SaveChangesAsync();
            // Act
            var result = await incomeSourceRepository.GetByIdAsync(incomeSource.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Income Source", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundException()
        {
            // Arrange
            var db = CreateDbContext();
            var incomeSourceRepository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Source",
                IncomeSubsource =
                    new IncomeSubsource
                    {
                        Id = Guid.NewGuid(),
                        Name = "Test Income Subsource"
                    }
            };
            await db.IncomeSources.AddAsync(incomeSource);
            await db.SaveChangesAsync();
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await incomeSourceRepository.GetByIdAsync(Guid.NewGuid());
            });
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllIncomeSources()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = new Guid(),
                Name = "Test income Source",
                IncomeSubsource = new IncomeSubsource
                {
                    Id = new Guid(),
                    Name = "Test Income Subsource",
                }
            };
            var incomeSource2 = new IncomeSource
            {
                Id = new Guid(),
                Name = "Test income Source2",
                IncomeSubsource = new IncomeSubsource
                {
                    Id = new Guid(),
                    Name = "Test Income Subsource2",
                }
            };
            await db.IncomeSources.AddRangeAsync(incomeSource, incomeSource2);
            await db.SaveChangesAsync();
            // Act
            var result = await repository.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateIncomeSource()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Source",
                IncomeSubsource = new IncomeSubsource
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Income Subsource"
                }
            };
            await db.IncomeSources.AddAsync(incomeSource);
            await db.SaveChangesAsync();
            // Act
            incomeSource.Name = "Updated Income Source";
            await repository.UpdateAsync(incomeSource);
            // Assert
            var result = await db.IncomeSources.FirstOrDefaultAsync(i => i.Id == incomeSource.Id);
            Assert.NotNull(result);
            Assert.Equal("Updated Income Source", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteIncomeSource()
        {
            // Arrange
            var db = CreateDbContext();
            var repository = new SQLIncomeSourceRepository(db);
            var incomeSource = new IncomeSource
            {
                Id = Guid.NewGuid(),
                Name = "Test Income Source",
                IncomeSubsource = new IncomeSubsource
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Income Subsource"
                }
            };
            await db.IncomeSources.AddAsync(incomeSource);
            await db.SaveChangesAsync();
            // Act
            await repository.DeleteAsync(incomeSource.Id);
            // Assert
            var result = await db.IncomeSources.FirstOrDefaultAsync(i => i.Id == incomeSource.Id);
            Assert.Null(result);
        }
    }
}
