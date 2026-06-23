namespace AdventureGuildApi.Models
{
    public class Adventurers
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string GuildRank { get; set; } = string.Empty;
        public int Gold { get; set; }
        public int Experience { get; set; }

    }
}
