using AdventureGuildApi.Models;

namespace AdventureGuildApi.Services
{
    public interface IAdventurerService
    {
        Task<List<Adventurer>> GetAllAsync();
        Task<Adventurer?> GetByIdAsync(int id);
        Task<Adventurer> CreateAsync(Adventurer newAdventurer);
        Task<Adventurer?> UpdateAsync(int id, Adventurer updateAdventurer);
        Task<bool> DeleteAsync(int id);
    }
}
