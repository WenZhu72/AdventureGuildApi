using AdventureGuildApi.Models;

namespace AdventureGuildApi.Services;

public class AdventurerService : IAdventurerService
{
    private readonly List<Adventurer> _adventurers = new()
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

    public List<Adventurer> GetAll()
    {
        return _adventurers;
    }
}