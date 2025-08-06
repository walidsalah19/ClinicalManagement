using ClinicalManagement.Application.Behavier;
using ClinicalManagement.Application.Extentions;
using FluentValidation;
using Hangfire.Logging;
using MediatR;
using Serilog;


namespace ClinicalManagement.Extentions
{
    public static class ApiExtentintions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //عشان نتبع ال endpoint والوقت بتاعها 
            services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Auto;
                options.TrackConnectionOpenClose = true;
            }).AddEntityFramework();


            //استخدام ال serilog عشان نعمل logging 
            Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .Enrich.WithEnvironmentName()
                        .Enrich.WithMachineName()
                        .Enrich.WithThreadId()
                        .WriteTo.Console()
                        .CreateLogger();


            //cors policy
            services.AddCors(options =>
            {
                options.AddPolicy("default", policy =>
                {
                    policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            return services;
        }
    }
}
