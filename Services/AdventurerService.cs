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

    public async Task<Adventurer?> GetByIdAsync(int id)
    {
        return await _dbContext.Adventurers.FindAsync(id);
    }

    public async Task<Adventurer> CreateAsync(Adventurer newAdventurer)
    {
        _dbContext.Adventurers.Add(newAdventurer);
        await _dbContext.SaveChangesAsync();

        return newAdventurer;
    }

    public async Task<Adventurer?> UpdateAsync(int id, Adventurer updatedAdventurer)
    {
        var existingAdventurer =
            await _dbContext.Adventurers.FindAsync(id);

        if (existingAdventurer is null)
        {
            return null;
        }

        existingAdventurer.Name = updatedAdventurer.Name;
        existingAdventurer.Level = updatedAdventurer.Level;
        existingAdventurer.GuildRank = updatedAdventurer.GuildRank;
        existingAdventurer.Gold = updatedAdventurer.Gold;
        existingAdventurer.Experience = updatedAdventurer.Experience;

        await _dbContext.SaveChangesAsync();

        return existingAdventurer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingAdventurer =
            await _dbContext.Adventurers.FindAsync(id);

        if (existingAdventurer is null)
        {
            return false;
        }

        _dbContext.Adventurers.Remove(existingAdventurer);
        
        await _dbContext.SaveChangesAsync();

        return true;
    }
}