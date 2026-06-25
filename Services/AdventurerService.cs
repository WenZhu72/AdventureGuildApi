using AdventureGuildApi.Data;
using AdventureGuildApi.Models;

using Microsoft.EntityFrameworkCore;

namespace AdventureGuildApi.Services;

public class AdventurerService : IAdventurerService
{
    private readonly AdventureGuildDbContext _dbContext;

    public AdventurerService(AdventureGuildDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Adventurer>> GetAllAsync()
    {
        return await _dbContext.Adventurers.ToListAsync();
    }

    public Adventurer? GetById(int id)
    {
        return _dbContext.Adventurers.FirstOrDefault(adventurer => adventurer.Id == id);
    }

    public Adventurer Create(Adventurer newAdventurer)
    {
        _dbContext.Adventurers.Add(newAdventurer);
        _dbContext.SaveChanges();

        return newAdventurer;
    }

    public Adventurer? Update(int id, Adventurer updatedAdventurer)
    {
        var existingAdventurer =
            _dbContext.Adventurers.FirstOrDefault(adventurer => adventurer.Id == id);

        if (existingAdventurer is null)
        {
            return null;
        }

        existingAdventurer.Name = updatedAdventurer.Name;
        existingAdventurer.Level = updatedAdventurer.Level;
        existingAdventurer.GuildRank = updatedAdventurer.GuildRank;
        existingAdventurer.Gold = updatedAdventurer.Gold;
        existingAdventurer.Experience = updatedAdventurer.Experience;

        _dbContext.SaveChanges();

        return existingAdventurer;
    }

    public bool Delete(int id)
    {
        var existingAdventurer =
            _dbContext.Adventurers.FirstOrDefault(adventurer => adventurer.Id == id);

        if (existingAdventurer is null)
        {
            return false;
        }

        _dbContext.Adventurers.Remove(existingAdventurer);
        _dbContext.SaveChanges();

        return true;
    }
}