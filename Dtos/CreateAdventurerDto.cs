namespace AdventureGuildApi.Dtos
{
    public class CreateAdventurerDto
    {
        public string Name { get; set; } = string.Empty;
        public int Level {  get; set; }
        public string GuildRank { get; set; } = string.Empty;
        public int Gold { get; set; }
        public int Experience { get; set; }
    }
}
