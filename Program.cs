using AdventureGuildApi.Endpoints;
using AdventureGuildApi.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddValidationServices();
builder.Services.AddExceptionHandling();

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