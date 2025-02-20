using EventManagement.CleanArchitecture.Api.Middleware;
using EventManagement.CleanArchitecture.Application;
using EventManagement.CleanArchitecture.Infrastructure;
using EventManagement.CleanArchitecture.Persistence;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

namespace EventManagement.CleanArchitecture.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestHeaders.Add("Correlation-Id");
                logging.ResponseHeaders.Add("Correlation-Id");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });

            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddInfrastructureServices(builder.Configuration);

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCustomCorrelationId();
            app.UseHttpLogging();
            app.UseCors("Open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EventManagement.CleanArchitecture.Api v1"));
            }

            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            try
            {
                var context = scope.ServiceProvider.GetService<EventManagementDbContext>();

                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred while migrating the database");
                throw;
            }
        }
    }
}
