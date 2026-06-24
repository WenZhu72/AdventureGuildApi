using AdventureGuildApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var adventurers = new List<Adventurer>
{
    new Adventurer
    {
        Id = 1,
        Name = "Aria Stormblade",
        Level = 5,
        GuildRank = "Bronze",
        Gold = 120,
        Experience = 450
    },
    new Adventurer
    {
        Id = 2,
        Name = "Borin Ironfist",
        Level = 8,
        GuildRank = "Silver",
        Gold = 300,
        Experience = 1200
    }
};

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

app.MapGet("/adventurers", () =>
{
    return Results.Ok(adventurers);
})
.WithName("GetAdventurers");

app.MapGet("/adventurers/{id}", (int id) =>
{
    var foundAdventurer =
        adventurers.FirstOrDefault(adventurer => adventurer.Id == id);

    if (foundAdventurer is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(foundAdventurer);
})
.WithName("GetAdventurerById");

app.MapPost("/adventurers", (Adventurer newAdventurer) =>
{
    newAdventurer.Id = adventurers.Max(adventurer => adventurer.Id) + 1;

    adventurers.Add(newAdventurer);

    return Results.Created($"/adventurers/{newAdventurer.Id}", newAdventurer);
})
.WithName("CreateAdventurer");

app.MapPut("/adventurers/{id}", (int id, Adventurer updatedAdventurer) =>
{
    var existingAdventurer =
        adventurers.FirstOrDefault(adventurer => adventurer.Id == id);

    if (existingAdventurer is null)
    {
        return Results.NotFound();
    }

    existingAdventurer.Name = updatedAdventurer.Name;
    existingAdventurer.Level = updatedAdventurer.Level;
    existingAdventurer.GuildRank = updatedAdventurer.GuildRank;
    existingAdventurer.Gold = updatedAdventurer.Gold;
    existingAdventurer.Experience = updatedAdventurer.Experience;

    return Results.Ok(existingAdventurer);
})
.WithName("UpdateAdventurer");

app.Run();