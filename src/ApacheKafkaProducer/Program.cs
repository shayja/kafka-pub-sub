// CA1852 Type 'Program' can be sealed because it has no subtypes in its containing assembly and is not externally visible
#pragma warning disable CA1852
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices();

// Configure JSON logging to the console.
//builder.Logging.AddJsonConsole();

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");

// Setup Services
var app = builder.Build();
app.ConfigureAppRouting();
app.ConfigureAppMiddleware();

// Start the Server
app.Run();
