using AdventureGuildApi.Dtos;
using AdventureGuildApi.Models;

namespace AdventureGuildApi.Mappings;


public static class AdventurerMapping
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
}
