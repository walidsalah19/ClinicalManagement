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
using MediatR;
using Hangfire;
using FluentValidation;
using ClinicalManagement.Application.Abstractions.Jop;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Infrastructure.Reposatories;
using ClinicalManagement.Domain.Models;
using ClinicalManagement.Infrastructure.Services.IdentityServices;
using ClinicalManagement.Application.Abstractions.Services.IdentityServices;
using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Infrastructure.Services.AuthServices;
using ClinicalManagement.Infrastructure.UnitOFWork;
using ClinicalManagement.Infrastructure.Services.Jop;
using ClinicalManagement.Infrastructure.Services.SnedEmail;
using ClinicalManagement.Application.Abstractions.Caching;
using ClinicalManagement.Infrastructure.Services.Caching;
using ClinicalManagement.Application.Abstractions.SignalR;
using ClinicalManagement.Infrastructure.Services.SignalR;
using ClinicalManagement.Application.Abstractions.DbContext;
using ClinicalManagement.Application.Abstractions.Services.AppointmentServices;
using ClinicalManagement.Infrastructure.Services.AppointmentServices;
using ClinicalManagement.Application.Abstractions.Services.EmailServices;
using ClinicalManagement.Application.Abstractions.GenerateInvoicePdf;
using ClinicalManagement.Infrastructure.Services.InvoicePdf;


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
            services.AddIdentity<UserModel, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());


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
            services.AddScoped<ISendEmail, SendEmailServices>();
            services.AddScoped<ICachingServices, RedisCaching>();


            services.AddScoped<IUsersServices, UsersServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IGenerateInvoicePdfServices, GenerateInvoicePdfServices>();


            services.AddScoped(typeof(IBaseReposatory<>), typeof(BaseReposatory<>));

            services.AddScoped<IAppoointmentsRepo, AppointmentsRepo>();
            services.AddScoped<IAppointmentService, AppointmentService>();

            services.AddScoped<INotificationRepo, NotificationRepo>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ISignalrServices, SignalRservices>();
            services.AddSingleton<IConnectionMappingService, ConnectionMappingService>();


            // services.AddScoped<IUsersServices<UsersModel>, UsersServices<UsersModel>();

            return services;
        }
    }
}
