using AdventureGuildApi.Models;

namespace AdventureGuildApi.Services;

public class AdventurerService : IAdventurerService
{
    private readonly List<Adventurer> _adventurers = new()
    {
        new Adventurer
        {
            Id = 1,
            Name = "Aria Hail Stormblade",
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

    public Adventurer? GetById(int Id)
    {
        var foundAdventurer =
            _adventurers.FirstOrDefault(adventurer => adventurer.Id == Id);

        return foundAdventurer;
    }

    public Adventurer Create(Adventurer newAdventurer)
    {
        newAdventurer.Id = _adventurers.Max(adventurer => adventurer.Id) + 1;
        _adventurers.Add(newAdventurer);
        return newAdventurer;
    }

    public Adventurer? Update(int id, Adventurer updatedAdventurer)
    {
        var existingAdventurer =
            _adventurers.FirstOrDefault(adventurer =>adventurer.Id == id);

        if (existingAdventurer is null)
        {
            return null;
        }

        existingAdventurer.Name = updatedAdventurer.Name;
        existingAdventurer.Level = updatedAdventurer.Level;
        existingAdventurer.GuildRank = updatedAdventurer.GuildRank;
        existingAdventurer.Gold = updatedAdventurer.Gold;
        existingAdventurer.Experience = updatedAdventurer.Experience;

        return existingAdventurer;
    }

    public bool Delete(int id)
    {
        var existingAdventurer =
            _adventurers.FirstOrDefault(adventurer => adventurer.Id == id);

        if (existingAdventurer is null)
        {
            return false;
        }

        _adventurers.Remove(existingAdventurer);

        return true;
    }
}