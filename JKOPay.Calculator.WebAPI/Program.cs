using JKOPay.Calculator.Application.Constracts.Infrastructure.Message;
using JKOPay.Calculator.Application.Constracts.Infrastructure.Weather;
using JKOPay.Calculator.Application.Features.CalculateWeatherCoins;
using JKOPay.Calculator.Domain;
using JKOPay.Calculator.Infrastructure.Alert;
using JKOPay.Calculator.Infrastructure.Weather;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IWeatherService, CWAWeatherService>();
builder.Services.AddScoped<IAllertService, DummyAlertService>();
builder.Services.AddScoped<IDiscounService, DiscounService>();

builder.Services.AddMediatR(config =>
{
    var applicationAssembly = typeof(CalculateWeatherCoinsQueryHandler).Assembly;
    config.RegisterServicesFromAssembly(applicationAssembly);
});

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


public partial class Program { }