using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ClinicalManagement.Application.Validations;
using ClinicalManagement.Application.Behavier;
using MediatR;


namespace ClinicalManagement.Application.Extentions
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // التسجيل من خلال Assembly للـ Application
            services.AddMediatR(options =>
                options.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

            services.AddValidatorsFromAssembly(typeof(ApplicationServiceRegistration).Assembly);
            // pipeline registration 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPipline<,>));

            // لو عندك AutoMapper
            services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);

            return services;
        }
    }
}
