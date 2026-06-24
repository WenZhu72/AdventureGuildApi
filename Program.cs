using AdventureGuildApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var adventurers = new List<Adventurer>
{
    new Adventurer
    {
        Id= 1,
        Name = "Aria Stormblade",
        Level = 5,
        GuildRank = "Bronze",
        Gold = 120,
        Experience = 450,
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
}).WithName("GetGuildInfo");

app.MapGet("/adventurers", () =>
{
    return Results.Ok(adventurers);
}).WithName("GetAdventurers");


app.Run();