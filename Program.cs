using AdventureGuildApi.Models;
using AdventureGuildApi.Services;
using AdventureGuildApi.Data;
using AdventureGuildApi.Dtos;
using AdventureGuildApi.Mappings;

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
    List<Adventurer> adventurers = await adventurerService.GetAllAsync();

    List<AdventurerResponseDto> adventurerResponseDtos = adventurers
    .Select(adventurer => adventurer.ToResponseDto())
    .ToList();

    return Results.Ok(adventurerResponseDtos);
})
.WithName("GetAdventurers");

app.MapGet("/adventurers/{id}", async (int id, IAdventurerService adventurerService) =>
{
    Adventurer? foundAdventurer = await adventurerService.GetByIdAsync(id);

    if (foundAdventurer is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(foundAdventurer.ToResponseDto());
})
.WithName("GetAdventurerById");

app.MapPost("/adventurers", async (CreateAdventurerDto createAdventurerDto, IAdventurerService adventurerService) =>
{
    Adventurer newAdventurer = new Adventurer
    {
        Name = createAdventurerDto.Name,
        Level = createAdventurerDto.Level,
        GuildRank = createAdventurerDto.GuildRank,
        Gold = createAdventurerDto.Gold,
        Experience = createAdventurerDto.Experience
    };

    Adventurer createdAdventurer = await adventurerService.CreateAsync(newAdventurer);

    AdventurerResponseDto adventurerResponseDto = createdAdventurer.ToResponseDto();

    return Results.Created($"/adventurers/{adventurerResponseDto.Id}", adventurerResponseDto);
})
.WithName("CreateAdventurer");

app.MapPut("/adventurers/{id}", async (int id, UpdateAdventurerDto updateAdventurerDto, IAdventurerService adventurerService) =>
{
    Adventurer updatedAdventurer = new Adventurer
    {
        Name = updateAdventurerDto.Name,
        Level = updateAdventurerDto.Level,
        GuildRank = updateAdventurerDto.GuildRank,
        Gold = updateAdventurerDto.Gold,
        Experience = updateAdventurerDto.Experience
    };


    Adventurer? updatedAdventurerResult
    = await adventurerService.UpdateAsync(id, updatedAdventurer);
    
    if (updatedAdventurerResult is null)
    {
        return Results.NotFound();
    }

    AdventurerResponseDto adventurerResponseDto = updatedAdventurerResult.ToResponseDto();

    return Results.Ok(adventurerResponseDto);
})
.WithName("UpdateAdventurer");

app.MapDelete("/adventurers/{id}", async (int id, IAdventurerService adventurerService) =>
{
    bool wasDeleted = await adventurerService.DeleteAsync(id);
    
    if (!wasDeleted)
    {
        return Results.NotFound();
    }

    return Results.NoContent();
})
.WithName("DeleteAdventurer");

app.Run();