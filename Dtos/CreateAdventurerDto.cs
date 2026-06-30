using System.ComponentModel.DataAnnotations;

namespace AdventureGuildApi.Dtos
{
    public class CreateAdventurerDto
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; } = string.Empty;
        public int Level {  get; set; }
        public string GuildRank { get; set; } = string.Empty;
        public int Gold { get; set; }
        public int Experience { get; set; }
    }
}
