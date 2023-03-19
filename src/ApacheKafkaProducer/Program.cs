using ApacheKafkaProducer.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices();

// Configure JSON logging to the console.
//builder.Logging.AddJsonConsole();

var app = builder.Build();


app.ConfigureApp();


app.Run();
