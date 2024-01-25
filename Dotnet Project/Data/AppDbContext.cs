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
                .WithMany(l => l.Players)
                .HasForeignKey(p => p.LinkedLobbyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lobby>()
                .HasOne(l => l.TimeSlot)
                .WithMany(t => t.LinkedLobbies)
                .HasForeignKey(l => l.TimeSlotId)
                .IsRequired();
            

            modelBuilder.Entity<Time_Slot>()
                .HasOne(t => t.stadium)
                .WithMany()
                .HasForeignKey(t => t.StadiumId);

            modelBuilder.Entity<Stadium>()
                .HasMany(s => s.Times)
                .WithOne(t => t.stadium)
                .HasForeignKey(t => t.StadiumId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Stade_Owner>()
                .HasOne(so => so.stade)
                .WithMany()
                .HasForeignKey(so => so.StadeId);

            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Players)
                .WithOne(p => p.LinkedLobby)
                .HasForeignKey(p => p.LinkedLobbyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Time_Slot>()
                .HasMany(l => l.LinkedLobbies)
                .WithOne(p => p.TimeSlot)
                .HasForeignKey(p => p.TimeSlotId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Configure the TeamNumber property
            modelBuilder.Entity<Player>()
                .Property(p => p.TeamNumber)
                .IsRequired();

            // Seed Players
            modelBuilder.Entity<Player>().HasData(
                new Player { ID = 1, EMail = "player1@example.com", mdp = "password1", Name = "Ala", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false , LinkedLobbyId= null},
                new Player { ID = 2, EMail = "player2@example.com", mdp = "password2", Name = "Taher", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false , LinkedLobbyId = null },
                new Player { ID = 3, EMail = "player3@example.com", mdp = "password3", Name = "Habib", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 4, EMail = "player4@example.com", mdp = "password4", Name = "Fedy", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 5, EMail = "player5@example.com", mdp = "password5", Name = "Najar", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 6, EMail = "player6@example.com", mdp = "password5", Name = "Reb3i", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 7, EMail = "player7@example.com", mdp = "password5", Name = "Ghazi", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 8, EMail = "player8@example.com", mdp = "password5", Name = "Kamel", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 9, EMail = "player9@example.com", mdp = "password5", Name = "Karim", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 10, EMail = "play10@example.com", mdp = "password1", Name = "Samir", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 11, EMail = "play11@example.com", mdp = "password1", Name = "Kais", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 12, EMail = "play12@example.com", mdp = "password1", Name = "Aziz", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 13, EMail = "play13@example.com", mdp = "password1", Name = "Youssef", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 14, EMail = "play14@example.com", mdp = "password1", Name = "Hamza", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 15, EMail = "play15@example.com", mdp = "password1", Name = "Ali", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 16, EMail = "play16@example.com", mdp = "password1", Name = "Mustafa", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 17, EMail = "play16@example.com", mdp = "password1", Name = "Elyess", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 18, EMail = "play16@example.com", mdp = "password1", Name = "Omar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 19, EMail = "play16@example.com", mdp = "password1", Name = "Ismail", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 20, EMail = "play16@example.com", mdp = "password1", Name = "Amine", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 21, EMail = "play16@example.com", mdp = "password1", Name = "Talel", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 22, EMail = "play16@example.com", mdp = "password1", Name = "Chehata", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null }
            // Add more players as needed
            );

            // Seed Stadiums
            modelBuilder.Entity<Stadium>().HasData(
                new Stadium { Id = 1, Name = "Stadium1", Description = "Description1", Localisation = "Location1", PhotoPath = "path1"},
                new Stadium { Id = 2, Name = "Stadium2", Description = "Description2", Localisation = "Location2", PhotoPath = "path2"},
                new Stadium { Id = 3, Name = "Stadium3", Description = "Description3", Localisation = "Location3", PhotoPath = "path2" }
                // Add more stadiums as needed
            );

            // Seed Time Slots
            modelBuilder.Entity<Time_Slot>().HasData(
                new Time_Slot { Id = 1, occupancy = true, StadiumId = 1, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies=new List<Lobby>()},  
                new Time_Slot { Id = 2, occupancy = false, StadiumId = 2, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies=new List<Lobby>() },
                new Time_Slot { Id = 3, occupancy = false, StadiumId = 3, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies=new List<Lobby>()},
                new Time_Slot { Id = 4, occupancy = false, StadiumId = 1, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30), LinkedLobbies = new List<Lobby>() },
                new Time_Slot { Id = 5, occupancy = false, StadiumId = 2, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30), LinkedLobbies = new List<Lobby>() },
                new Time_Slot { Id = 6, occupancy = false, StadiumId = 3, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30), LinkedLobbies = new List<Lobby>() }

            // Add more time slots as needed
            );

    
            // Seed Stade Owners
            modelBuilder.Entity<Stade_Owner>().HasData(
                new Stade_Owner { ID = 1, Name = "Owner1", Surname = "Owner1Surname", EMail = "owner1@example.com", mdp = "password1"},
                new Stade_Owner { ID = 2, Name = "Owner2", Surname = "Owner2Surname", EMail = "owner2@example.com", mdp = "password2"}
            // Add more stade owners as needed
            );


            base.OnModelCreating(modelBuilder);
        }

    }
}