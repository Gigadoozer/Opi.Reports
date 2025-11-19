using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Opi.Reports.Application;
using Opi.Reports.Application.Validators;
using Opi.Reports.Infrastructure;
using Opi.Reports.Infrastructure.DI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// FluentValidation
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(typeof(CreateReportValidator).Assembly);

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly)
);

// Infrastructure
builder.Services.AddInfrastructureServices();

// CORS
builder.Services.AddCors(o =>
    o.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

var app = builder.Build();

// Middleware
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
