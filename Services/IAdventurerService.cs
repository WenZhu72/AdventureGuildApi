using AdventureGuildApi.Models;

namespace AdventureGuildApi.Services
{
    public interface IAdventurerService
    {
        Task<List<Adventurer>> GetAllAsync();
        Adventurer? GetById(int id);
        Adventurer Create(Adventurer newAdventurer);
        Adventurer? Update(int id, Adventurer updateAdventurer);
        bool Delete(int id);
    }
}
