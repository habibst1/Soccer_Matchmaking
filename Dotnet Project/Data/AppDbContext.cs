using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Time_Slot> TimeSlots { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Stade_Owner> StadeOwners { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.LinkedLobby)
                .WithMany()
                .HasForeignKey(p => p.LinkedLobbyId);

            modelBuilder.Entity<Lobby>()
                .HasOne(l => l.t)
                .WithMany()
                .HasForeignKey(l => l.TimeSlotId);

            modelBuilder.Entity<Time_Slot>()
                .HasOne(t => t.stadium)
                .WithMany()
                .HasForeignKey(t => t.StadiumId);

            modelBuilder.Entity<Stade_Owner>()
                .HasOne(so => so.stade)
                .WithMany()
                .HasForeignKey(so => so.StadeId);

            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Team1)
                .WithOne(p => p.LinkedLobby)
                .HasForeignKey(p => p.LinkedLobbyId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed

            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Team2)
                .WithOne(p => p.LinkedLobby)
                .HasForeignKey(p => p.LinkedLobbyId)
                .OnDelete(DeleteBehavior.Restrict); // Adjust the delete behavior as needed


            base.OnModelCreating(modelBuilder);
        }
    }
}