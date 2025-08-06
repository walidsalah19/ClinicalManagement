using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ClinicalManagement.Infrastructure.Jop;
using MediatR;
using Hangfire;
using FluentValidation;
using ClinicalManagement.Application.Abstractions.Jop;
using ClinicalManagement.Application.Abstractions.Services;
using ClinicalManagement.Infrastructure.Services;

namespace ClinicalManagement.Infrastructure.Extentions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
                   .LogTo(Console.WriteLine, LogLevel.Information);
            });
            services.AddIdentity<UsersModel, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetConnectionString("Redis");
            });
            services.AddHangfire((sp, config) =>
            {
                var connection = sp.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection");
                config.UseSqlServerStorage(connection);
            });
             services.AddHangfireServer();
            

            services.AddScoped<IhangfireJop, HangfireJop>();
            services.AddScoped<IRoleServices, RoleServices>();
            services.AddScoped<IUsersServices, UsersServices>();

            return services;
        }
    }
}
