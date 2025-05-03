using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Expenses;
using HomeBudget.API.Repositories.ExpenseRepositories;
using Microsoft.EntityFrameworkCore;

namespace Repository.Tests.ExpenseRepositoryTests
{
    public class ExpenseSubsourceRepositoryTests
    {
        private readonly DbContextOptions<HomeBudgetDbContext> _options;
        public ExpenseSubsourceRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<HomeBudgetDbContext>()
                .UseInMemoryDatabase(databaseName: "HomeBudgetTestDb")
                .Options;
        }
        private HomeBudgetDbContext CreateDbContext() => new HomeBudgetDbContext(_options);
        [Fact]
        public async Task CreateAsync_ShouldCreateExpenseSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var expenseSubsource = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource"
            };
            // Act
            await expenseSubsourceRepository.CreateAsync(expenseSubsource);
            // Assert
            var result = await db.ExpenseSubsorts.FirstOrDefaultAsync(e => e.Name == "Test Expense Subsource");
            Assert.NotNull(result);
            Assert.Equal("Test Expense Subsource", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnExpenseSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var expenseSubsource = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource"
            };
            await db.ExpenseSubsorts.AddAsync(expenseSubsource);
            await db.SaveChangesAsync();
            // Act
            var result = await expenseSubsourceRepository.GetByIdAsync(expenseSubsource.Id);
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Expense Subsource", result.Name);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldThrowKeyNotFoundExceotion()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var id = Guid.NewGuid();
            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(async () => await expenseSubsourceRepository.GetByIdAsync(id));
        }
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllExpenseSubsources()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var expenseSubsource1 = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource 1"
            };
            var expenseSubsource2 = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource 2"
            };
            await db.ExpenseSubsorts.AddRangeAsync(expenseSubsource1, expenseSubsource2);
            await db.SaveChangesAsync();
            // Act
            var result = await expenseSubsourceRepository.GetAllAsync();
            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
        [Fact]
        public async Task UpdateAsync_ShouldUpdateExpenseSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var expenseSubsource = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource"
            };
            await db.ExpenseSubsorts.AddAsync(expenseSubsource);
            await db.SaveChangesAsync();
            // Act
            expenseSubsource.Name = "Updated Expense Subsource";
            await expenseSubsourceRepository.UpdateAsync(expenseSubsource);
            // Assert
            var result = await db.ExpenseSubsorts.FirstOrDefaultAsync(e => e.Id == expenseSubsource.Id);
            Assert.NotNull(result);
            Assert.Equal("Updated Expense Subsource", result.Name);
        }
        [Fact]
        public async Task DeleteAsync_ShouldDeleteExpenseSubsource()
        {
            // Arrange
            var db = CreateDbContext();
            var expenseSubsourceRepository = new SQLExpenseSubSortRepository(db);
            var expenseSubsource = new ExpenseSubsort
            {
                Id = Guid.NewGuid(),
                Name = "Test Expense Subsource"
            };
            await db.ExpenseSubsorts.AddAsync(expenseSubsource);
            await db.SaveChangesAsync();
            // Act
            await expenseSubsourceRepository.DeleteAsync(expenseSubsource.Id);
            // Assert
            var result = await db.ExpenseSubsorts.FirstOrDefaultAsync(e => e.Id == expenseSubsource.Id);
            Assert.Null(result);
        }
    }
}
