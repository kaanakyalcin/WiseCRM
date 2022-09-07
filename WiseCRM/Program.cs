using WiseCRM.Models;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

var server = "ms-sql-server";
var port = "1433";
var user = "SA";
var password = "149024As";
var database = "Colors";

builder.Services.AddDbContext<ColorContext>(x => x.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID={user};Password={password}"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*ConfigurationOptions option = new ConfigurationOptions
    {
        AbortOnConnectFail = false,
        EndPoints = { "rediscache" }
    };
var redis = ConnectionMultiplexer.Connect("rediscache");
builder.Services.AddScoped(s => redis.GetDatabase());*/


builder.Services.AddHealthChecks();
var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PrepDB.PrepPopulation(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
