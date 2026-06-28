using AdventureGuildApi.Dtos;
using AdventureGuildApi.Models;

namespace AdventureGuildApi.Mappings
{
    public static class AdventurerMappingExtensions
    {
        public static AdventurerResponseDto ToResponseDto(this Adventurer adventurer)
        {
            return new AdventurerResponseDto
            {
                Id = adventurer.Id,
                Name = adventurer.Name,
                Level = adventurer.Level,
                GuildRank = adventurer.GuildRank,
                Gold = adventurer.Gold,
                Experience = adventurer.Experience
            };
        }

        public static Adventurer ToEntity(this CreateAdventurerDto createAdventurerDto)
        {
            return new Adventurer
            {
                Name = createAdventurerDto.Name,
                Level = createAdventurerDto.Level,
                GuildRank = createAdventurerDto.GuildRank,
                Gold = createAdventurerDto.Gold,
                Experience = createAdventurerDto.Experience
            };
        }
    }
}