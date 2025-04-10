using Carter;
using Common.Behaviors;
using Common.Extensions;
using FluentValidation;
using IdentityService.Application;
using IdentityService.Domain.Interfaces;
using IdentityService.Infrastructure.Data;
using IdentityService.Infrastructure.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

var applicationAssembly = Global.Assembly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(applicationAssembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddCarter();
builder.Services.AddMapster();
builder.Services.AddCommandHandlersFromAssembly(applicationAssembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.Run();