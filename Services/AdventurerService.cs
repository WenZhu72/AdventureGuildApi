using AdventureGuildApi.Data;
using AdventureGuildApi.Models;

using Microsoft.EntityFrameworkCore;

namespace AdventureGuildApi.Services;

public class AdventurerService : IAdventurerService
{
    private readonly AdventureGuildDbContext _dbContext;
    private readonly ILogger<AdventurerService> _logger;

    public AdventurerService(
        AdventureGuildDbContext dbContext,
        ILogger<AdventurerService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<Adventurer>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all adventurers");

        return await _dbContext.Adventurers.ToListAsync();
    }

    public async Task<Adventurer?> GetByIdAsync(int id)
    {
        var adventurer = await _dbContext.Adventurers.FindAsync(id);

        if (adventurer is null)
        {
            _logger.LogWarning(
                "Adventurer with ID {AdventurerId} was not found",
                id);
        }

        return adventurer;
    }

    public async Task<Adventurer> CreateAsync(Adventurer newAdventurer)
    {
        _logger.LogInformation(
            "Creating adventurer with name {AdventurerName}",
            newAdventurer.Name);

        _dbContext.Adventurers.Add(newAdventurer);
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(
            "Created adventurer with ID {AdventurerId}",
            newAdventurer.Id);

        return newAdventurer;
    }

    public async Task<Adventurer?> UpdateAsync(int id, Adventurer updatedAdventurer)
    {
        var existingAdventurer =
            await _dbContext.Adventurers.FindAsync(id);

        if (existingAdventurer is null)
        {
            _logger.LogWarning(
                "Attempted to update adventurer with ID {AdventurerId}, but it was not found",
                id);

            return null;
        }

        existingAdventurer.Name = updatedAdventurer.Name;
        existingAdventurer.Level = updatedAdventurer.Level;
        existingAdventurer.GuildRank = updatedAdventurer.GuildRank;
        existingAdventurer.Gold = updatedAdventurer.Gold;
        existingAdventurer.Experience = updatedAdventurer.Experience;

        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(
            "Updated adventurer with ID {AdventurerId}",
            id);

        return existingAdventurer;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingAdventurer =
            await _dbContext.Adventurers.FindAsync(id);

        if (existingAdventurer is null)
        {
            _logger.LogWarning(
                "Attempted to delete adventurer with ID {AdventurerID}, but it was not found",
                id);

            return false;
        }

        _dbContext.Adventurers.Remove(existingAdventurer);
        
        await _dbContext.SaveChangesAsync();

        _logger.LogInformation(
            "Deleted adventurer with ID {AdventurerId}",
            id);

        return true;
    }
}