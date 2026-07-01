using AdventureGuildApi.Data;
using AdventureGuildApi.Dtos;
using AdventureGuildApi.Endpoints;
using AdventureGuildApi.Services;
using AdventureGuildApi.Validators;

using AdventureGuildApi.Infrastructure.Filters;
using AdventureGuildApi.Infrastructure.ExceptionHandling;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdventurerService, AdventurerService>();

builder.Services.AddScoped<IValidator<CreateAdventurerDto>, CreateAdventurerDtoValidator>();
builder.Services.AddScoped<IValidator<UpdateAdventurerDto>, UpdateAdventurerDtoValidator>();

builder.Services.AddScoped(typeof(ValidationFilter<>));

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AdventureGuildDbContext>(options =>
    options.UseSqlite("Data Source = adventureguild.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.MapGuildEndpoints();
app.MapAdventurerEndpoints();

app.Run();