
using ClinicalManagement.Application.Behavier;
using ClinicalManagement.Application.Extentions;
using ClinicalManagement.Application.User.Commands;
using ClinicalManagement.Application.Validations;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Infrastructure.Data;
using ClinicalManagement.Infrastructure.Extentions;
using ClinicalManagement.Middelwares;
using FluentValidation;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplicationServices();

         
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.ExceptionHandling();
            app.UseAuthorization();

            app.UseHangfireDashboard("/admin-jobs");
            app.MapControllers();

            app.Run();
        }
    }
}
