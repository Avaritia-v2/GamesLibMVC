using GamesLibMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibMVC.Models
{
    public class GamesContext : DbContext
    {
        public GamesContext(DbContextOptions<GamesContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameInfo> GamesInfo { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().ToTable("Genre");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<GameInfo>().ToTable("GameInfo");
        }
    }
}
