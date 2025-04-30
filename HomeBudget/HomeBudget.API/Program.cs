
using HomeBudget.API.Data;
using HomeBudget.API.Models.Domain.Users;
using HomeBudget.API.Repositories;
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
