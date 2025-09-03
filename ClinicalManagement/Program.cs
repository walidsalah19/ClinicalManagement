
using ClinicalManagement.Application.Abstractions;
using ClinicalManagement.Application.Behavier;
using ClinicalManagement.Application.Extentions;
using ClinicalManagement.Application.Validations;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Extentions;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Extentions;
using ClinicalManagement.Infrastructure.Services.SignalR;
using ClinicalManagement.Middelwares;
using FluentValidation;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
using QuestPDF.Infrastructure;
using Serilog;
using System;

namespace ClinicalManagement
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
          // builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddFluentEmail(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddApiServices();
            builder.Host.UseSerilog();
            builder.Services.AddSwaggerServices();
            builder.Services.AddAuthServices(builder.Configuration);


            //???? ?? questpdf ????? ????? 
            QuestPDF.Settings.License = LicenseType.Community;

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            //Adding Logging meddilware
            //builder.Host.UseSerilog();
            app.UseMiddleware<LoggingMiddleware>();
            app.ExceptionHandling();
            app.UseAuthorization();
            app.UseCors("default");
            app.UseHangfireDashboard("/admin-jobs");
            app.MapControllers();
            app.UseMiniProfiler();



            app.MapHub<SignalrHub>("/chat");
            app.Run();
        }
    }
}
