using EmployeeWebApp;
using EmployeeWebApp.Models;
using EmployeeWebApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<ApiContext>(options => options.UseInMemoryDatabase(databaseName: "Employee"));
builder.Services.AddScoped<IRepository,Repository>();
//builder.Services.AddScoped<ApiContext>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
DataSeed ds = new DataSeed(scope.ServiceProvider.GetRequiredService<ApiContext>());
ds.Initialize();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
