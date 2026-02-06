using SIGA.Application;
using SIGA.Application.Interfaces;
using SIGA.Infrastructure;
using SIGA.Persistence;
using SIGA.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(IReporteService<>), typeof(ReporteService<>));

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();
