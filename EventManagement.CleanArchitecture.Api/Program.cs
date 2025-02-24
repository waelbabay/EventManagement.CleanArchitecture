using EventManagement.CleanArchitecture.Api;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Event management API starting...");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(
    (context, services, configuration) =>
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console()
    );


var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

app.UseSerilogRequestLogging();

builder.Configuration.AddUserSecrets<Program>();

await app.ResetDatabaseAsync();

app.Run();
