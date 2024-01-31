using MyDapper.Application.Extensions;
using MyDapper.Persistence.DapperContextFolder;
using MyDapper.Persistence.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);



Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .WriteTo.File("Serilog/MyDapper_Log.txt", rollingInterval: RollingInterval.Minute)
   .MinimumLevel.Information()
   .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Database>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MigrateDatabase();
app.Run();
