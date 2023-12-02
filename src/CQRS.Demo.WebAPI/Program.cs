
using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories;
using FormulaOne.DataService.Repositories.Ineterfaces;
using Hangfire;
using Hangfire.SQLite;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Globalization;
using System.Reflection;

namespace FormulaOne.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            var HangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
            builder.Services.AddDbContext<ApplicationDbContext> (option=>option.UseSqlite(ConnectionString));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            builder.Services.AddHangfireServer();


            // Configer Hangfire Client 
            builder.Services.AddHangfire(config =>
            config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSQLiteStorage(HangfireConnectionString)
            );





            //Injecting The MediatR to our DI
            builder.Services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHangfireDashboard();
            app.MapHangfireDashboard("/hangfire");

            const int NUM = 1;
            

            RecurringJob.AddOrUpdate(() =>
            
            Console.WriteLine($"hello{NUM}"), Cron.Minutely);

            app.MapControllers();

            app.Run();
        }
    }
}