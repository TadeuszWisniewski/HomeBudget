
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Budgets;
using HomeBudget.API.Models.Domain.Currencies;
using HomeBudget.API.Models.Domain.Debts;
using HomeBudget.API.Models.Domain.Expenses;
using HomeBudget.API.Models.Domain.Incomes;
using HomeBudget.API.Models.Domain.Users;
using HomeBudget.API.Repositories;
using HomeBudget.API.Repositories.BudgetRepositories;
using HomeBudget.API.Repositories.CurrencyRepositories;
using HomeBudget.API.Repositories.DebtsRepositories;
using HomeBudget.API.Repositories.ExpenseRepositories;
using HomeBudget.API.Repositories.IncomeRepositories;
using HomeBudget.API.Repositories.UserRepositories;
using Microsoft.EntityFrameworkCore;

namespace HomeBudget.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<HomeBudgetDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HomeBudgetConnectionString")));

            builder.Services.AddScoped<IRepository<UserType>, SQLUserTypesRepository>();
            builder.Services.AddScoped<IRepository<User>, SQLUserRepository>();
            builder.Services.AddScoped<IRepository<IncomeSubsource>, SQLIncomeSubsourceRepository>();
            builder.Services.AddScoped<IRepository<IncomeSource>, SQLIncomeSourceRepository>();
            builder.Services.AddScoped<IRepository<Income>, SQLIncomeRepository>();
            builder.Services.AddScoped<IRepository<ExpenseSubsort>, SQLExpenseSubSortRepository>();
            builder.Services.AddScoped<IRepository<ExpenseSort>, SQLExpenseSortRepository>();
            builder.Services.AddScoped<IRepository<Expense>, SQLExpenseRepository>();
            builder.Services.AddScoped<IRepository<Debt>, SQLDebtRepository>();
            builder.Services.AddScoped<IRepository<Currency>, SQLCurrencyRepository>();
            builder.Services.AddScoped<IRepository<BudgetType>, SQLBudgetTypeRepository>();
            builder.Services.AddScoped<IRepository<BudgetDuration>, SQLBudgetDurationRepository>();
            builder.Services.AddScoped<IRepository<Budget>, SQLBudgetRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
