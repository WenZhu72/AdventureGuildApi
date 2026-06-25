using AdventureGuildApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdventureGuildApi.Data
{
    public class AdventureGuildDbContext : DbContext
    {
        public AdventureGuildDbContext(DbContextOptions<AdventureGuildDbContext> options)
            : base(options) 
        {
            
        }

        public DbSet<Adventurer> Adventurers
        {
            get; set;
        }
}
}
