using Microsoft.EntityFrameworkCore;
using TodoApi.Infrastructure.Persistance;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<CarsContext>(opt =>
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cars;Trusted_Connection=True;"));
builder.Services.AddDbContext<TE_TestProductivityContext>(opt =>
    opt.UseSqlServer("Server=AWUEA1GDLSQL41;Database=TE_TestProductivity;Trusted_Connection=True;Trust Server Certificate=true;"));
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

app.Run();
