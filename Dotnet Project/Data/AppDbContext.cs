using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Time_Slot> TimeSlots { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(p => p.LinkedLobby)
                .WithMany()
                .HasForeignKey(p => p.LinkedLobbyId);
                

            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Players);


            modelBuilder.Entity<Lobby>()
               .Property(p => p.playerids)
               .HasConversion(
                   v => string.Join(",", v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
               );



            modelBuilder.Entity<Lobby>()
                .HasOne(l => l.admin)
                .WithMany()
                .HasForeignKey(l => l.adminId);


            modelBuilder.Entity<Lobby>()
                .HasOne(l => l.TimeSlot)
                .WithMany(t => t.LinkedLobbies)
                .HasForeignKey(l => l.TimeSlotId)
                .IsRequired();


            modelBuilder.Entity<Time_Slot>()
                .HasOne(t => t.stadium)
                .WithMany(s => s.Times)
                .HasForeignKey(t => t.StadiumId);

            modelBuilder.Entity<Stadium>()
                .HasMany(s => s.Times)
                .WithOne(t => t.stadium)
                .HasForeignKey(t => t.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(so => so.stade)
                .WithMany()
                .HasForeignKey(so => so.StadeId);

            
            modelBuilder.Entity<Time_Slot>()
                .HasMany(l => l.LinkedLobbies)
                .WithOne(p => p.TimeSlot)
                .HasForeignKey(p => p.TimeSlotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the TeamNumber property
            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.TeamNumber)
                .IsRequired();

    

            base.OnModelCreating(modelBuilder);
        }

    }
}