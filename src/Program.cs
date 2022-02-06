using json_api_test;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers()
    .AddNewtonsoftJson();

builder.Services
    .AddSingleton<IStorage, StorageService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
