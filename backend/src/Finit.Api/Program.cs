using Finit.Api;

var env = Environment.GetEnvironmentVariable("ENV") ?? "dev";

// Create the builder
var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    ContentRootPath = Directory.GetCurrentDirectory()
});

// Load custom appsettings file based on ENV variable
builder.Configuration.AddJsonFile($"Config/appsettings-{env}.json", optional: false, reloadOnChange: false);

// Register services in Startup.cs
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure middleware in Startup.cs
startup.Configure(app, app.Environment);

// Run the app
app.Run();
