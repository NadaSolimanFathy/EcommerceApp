using Core.Context;
using Core.Entities;
using EcommerceApp.HandelResponses;
using EcommerceApp.Helper;
using EcommerceApp.Middlewares;
using InfraStructure;
using InfraStructure.Interfaces;
using InfraStructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Services.ProductService;

using Services.Services.ProductService.Dto;
using EcommerceApp.Extensions;
using StackExchange.Redis;
using Core.IdentityEntities;

namespace EcommerceApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
    
            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection"));
            });
            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"),true);

                return ConnectionMultiplexer.Connect(configuration);
            });
            

            builder.Services.AddApplicationServices();
            builder.Services.AddIdentityServiceExtention();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
         
            await ApplySeeding.ApplySeedingAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseMiddleware<ExceptionMiddleware>();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseAuthentication();
            app.MapControllers();
            app.Run();
        }
    }
}