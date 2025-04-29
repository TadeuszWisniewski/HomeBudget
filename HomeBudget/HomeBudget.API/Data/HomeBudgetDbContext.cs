using HomeBudget.API.Models.Domain.Accounts;
using HomeBudget.API.Models.Domain.Budgets;
using HomeBudget.API.Models.Domain.Currencies;
using HomeBudget.API.Models.Domain.Debts;
using HomeBudget.API.Models.Domain.Expenses;
using HomeBudget.API.Models.Domain.Incomes;
using HomeBudget.API.Models.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API.Data
{
    public class HomeBudgetDbContext : DbContext
    {
        public HomeBudgetDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseSort> ExpenseSorts { get; set; }
        public DbSet<ExpenseSubsort> ExpenseSubsorts { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeSource> IncomeSources { get; set; }
        public DbSet<IncomeSubsource> IncomeSubsource { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetType> BudgetTypes { get; set; }
        public DbSet<BudgetDuration> BudgetDurations { get; set; }
        public DbSet<Debt> Debts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Expense>()
                .HasMany(e => e.ExpenseSorts)
                .WithMany(e => e.Expenses)
                .UsingEntity(
                    "ExpenseExpenseSort",
                    l => l.HasOne(typeof(ExpenseSort)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Expense)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Income>()
                .HasMany(i => i.IncomeSources)
                .WithMany(i => i.Incomes)
                .UsingEntity(
                    "IncomeIncomeSource",
                    l => l.HasOne(typeof(IncomeSource)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Income)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Expenses)
                .WithMany(e => e.Accounts)
                .UsingEntity(
                    "AccountExpense",
                    l => l.HasOne(typeof(Expense)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Account)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Incomes)
                .WithMany(i => i.Accounts)
                .UsingEntity(
                    "AccountIncome",
                    l => l.HasOne(typeof(Income)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Account)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transfers)
                .WithMany(t => t.Accounts)
                .UsingEntity(
                    "AccountTransfer",
                    l => l.HasOne(typeof(Transfer)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Account)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithMany(a => a.Users)
                .UsingEntity(
                    "UserAccount",
                    l => l.HasOne(typeof(Account)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithMany(e => e.Users)
                .UsingEntity(
                    "UserExpense",
                    l => l.HasOne(typeof(Expense)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<User>()
                .HasMany(u => u.Incomes)
                .WithMany(i => i.Users)
                .UsingEntity(
                    "UserIncome",
                    l => l.HasOne(typeof(Income)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<User>()
                .HasMany(u => u.Debts)
                .WithMany(d => d.Users)
                .UsingEntity(
                    "UserDebt",
                    l => l.HasOne(typeof(Debt)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.ExpenseSubsorts)
                .WithMany(e => e.Budgets)
                .UsingEntity(
                    "BudgetExpense",
                    l => l.HasOne(typeof(ExpenseSubsort)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Budget)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<Debt>()
                .HasMany(b => b.Users)
                .WithMany(i => i.Debts)
                .UsingEntity(
                    "DebtUser",
                    l => l.HasOne(typeof(User)).WithMany().OnDelete(DeleteBehavior.NoAction),
                    r => r.HasOne(typeof(Debt)).WithMany().OnDelete(DeleteBehavior.NoAction)
                    );
            modelBuilder.Entity<User>()
                .HasOne(u => u.CoOperator)
                .WithMany(u => u.Cooperators)
                .HasForeignKey(u => u.CoOperatorId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
