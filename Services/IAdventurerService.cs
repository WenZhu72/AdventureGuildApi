using AdventureGuildApi.Models;

namespace AdventureGuildApi.Services
{
    public interface IAdventurerService
    {
        List<Adventurer> GetAll();
        Adventurer? GetById(int id);
        Adventurer Create(Adventurer newAdventurer);
        Adventurer? Update(int id, Adventurer updateAdventurer);
        bool Delete(int id);
    }
}
