using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RateThisDog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite("DataSource=/home/nistrum/dev/rate-this-dog/sqlite/rate-this-dog/sqlite/RateThisDog.db")
    .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Information)
    .EnableDetailedErrors(true)
    .EnableSensitiveDataLogging(true)
    );

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
