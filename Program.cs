using AdventureGuildApi.Models;
using AdventureGuildApi.Services;
using AdventureGuildApi.Data;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAdventurerService, AdventurerService>();

builder.Services.AddDbContext<AdventureGuildDbContext>(options =>
options.UseSqlite("Data Source = adventureguild.db"));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/guild", () =>
{
    var guildInfo = new
    {
        Name = "Adventure Guild",
        Location = "Ironhaven",
        RankSystem = "Bronze to Mythril"
    };

    return Results.Ok(guildInfo);
})
.WithName("GetGuildInfo");

app.MapGet("/adventurers", async (IAdventurerService adventurerService) =>
{
    var adventurers = await adventurerService.GetAllAsync();

    return Results.Ok(adventurers);
})
.WithName("GetAdventurers");

app.MapGet("/adventurers/{id}", async (int id, IAdventurerService adventurerService) =>
{
    Adventurer? foundAdventurer = await adventurerService.GetByIdAsync(id);

    if (foundAdventurer is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(foundAdventurer);
})
.WithName("GetAdventurerById");

app.MapPost("/adventurers", async (Adventurer newAdventurer, IAdventurerService adventurerService) =>
{
    Adventurer createdAdventurer = await adventurerService.CreateAsync(newAdventurer);

    return Results.Created($"/adventurers/{newAdventurer.Id}", newAdventurer);
})
.WithName("CreateAdventurer");

app.MapPut("/adventurers/{id}", async (int id, Adventurer updatedAdventurer, IAdventurerService adventurerService) =>
{
    Adventurer? updatedAdventurerResult
    = await adventurerService.UpdateAsync(id, updatedAdventurer);
    
    if (updatedAdventurerResult is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(updatedAdventurerResult);
})
.WithName("UpdateAdventurer");

app.MapDelete("/adventurers/{id}", (int id, IAdventurerService adventurerService) =>
{
    var wasDeleted = adventurerService.Delete(id);
    
    if (!wasDeleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();
})
.WithName("DeleteAdventurer");

app.Run();