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
                new Player { ID = 1, EMail = "player1@example.com", mdp = "password1", Name = "Ala", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 2, EMail = "player2@example.com", mdp = "password2", Name = "Taher", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 3, EMail = "player3@example.com", mdp = "password3", Name = "Habib", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 4, EMail = "player4@example.com", mdp = "password4", Name = "Fedy", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 5, EMail = "player5@example.com", mdp = "password5", Name = "Najar", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 6, EMail = "player6@example.com", mdp = "password6", Name = "Reb3i", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 7, EMail = "player7@example.com", mdp = "password7", Name = "Ghazi", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 8, EMail = "player8@example.com", mdp = "password8", Name = "Kamel", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 9, EMail = "player9@example.com", mdp = "password9", Name = "Karim", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 10, EMail = "play10@example.com", mdp = "password10", Name = "Samir", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 11, EMail = "play11@example.com", mdp = "password11", Name = "Kais", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 12, EMail = "play12@example.com", mdp = "password12", Name = "Aziz", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 13, EMail = "play13@example.com", mdp = "password13", Name = "Youssef", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 14, EMail = "play14@example.com", mdp = "password14", Name = "Hamza", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 15, EMail = "play15@example.com", mdp = "password15", Name = "Ali", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 16, EMail = "play16@example.com", mdp = "password16", Name = "Mustafa", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 17, EMail = "play17@example.com", mdp = "password17", Name = "Elyess", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 18, EMail = "play18@example.com", mdp = "password18", Name = "Omar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 19, EMail = "play19@example.com", mdp = "password19", Name = "Ismail", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 20, EMail = "play20@example.com", mdp = "password20", Name = "Amine", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 21, EMail = "play21@example.com", mdp = "passwor21", Name = "Talel", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 22, EMail = "play22@example.com", mdp = "password22", Name = "Yahya", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 23, EMail = "play23@example.com", mdp = "password23", Name = "Skander", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 24, EMail = "play24@example.com", mdp = "password24", Name = "Omar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 25, EMail = "play25@example.com", mdp = "password25", Name = "Zahran", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 26, EMail = "play26@example.com", mdp = "password26", Name = "Mohamed", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 27, EMail = "play27@example.com", mdp = "password27", Name = "Fethi", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 28, EMail = "play28@example.com", mdp = "password28", Name = "Adem", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 29, EMail = "play29@example.com", mdp = "password29", Name = "Ahmed", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 30, EMail = "play30@example.com", mdp = "password30", Name = "Ayhem", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 31, EMail = "play31@example.com", mdp = "password31", Name = "Abderrahmen", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 32, EMail = "play32@example.com", mdp = "password32", Name = "Hamdi", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 33, EMail = "play33@example.com", mdp = "password33", Name = "Majd", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 34, EMail = "play34@example.com", mdp = "password34", Name = "Bachar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new Player { ID = 35, EMail = "play35@example.com", mdp = "password35", Name = "Oussama", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null }
            // Add more players as needed
            );

            // Seed Stadiums
            modelBuilder.Entity<Stadium>().HasData(
                new Stadium { Id = 1, Name = "May Land", Description = "CHOUF 3CHIRI A9WA STADE F TUNIS KAMLA W YOUFA LA7DITH", Localisation = "Monastir", PhotoPath = "Images/StadeMay.png" },
                new Stadium { Id = 2, Name = "Five Stars", Description = "A9WA STADE FEL 3ASSMA", Localisation = "Route Géant", PhotoPath = "Images/StadeFive.png"},
                new Stadium { Id = 3, Name = "Stade Charguia", Description = "A5YEB STADE F TUNIS KAMLA", Localisation = "Charguia", PhotoPath = "Images/StadeCharguia.png" },
                new Stadium { Id = 4, Name = "MStadium", Description = "AWEL STADE F MAHDIA", Localisation = "Mahdia", PhotoPath = "Images/MStadium.png" },
                new Stadium { Id = 5, Name = "Parc Des Princes", Description = "A7SSEN STADE F MAHDIA", Localisation = "Rejiche", PhotoPath = "Images/PDP.png" },
                new Stadium { Id = 6, Name = "Al Kahna", Description = "STADE F WOST 7OMMA T5AWEF ", Localisation = "Monastir", PhotoPath = "Images/Kahna.png" },
                new Stadium { Id = 7, Name = "Stade Sahara Beach", Description = "EKTICHAF JDID", Localisation = "Monastir", PhotoPath = "Images/Sahara.png" }
                // Add more stadiums as needed
            );

            // Seed Time Slots
            modelBuilder.Entity<Time_Slot>().HasData(
                new Time_Slot { Id = 1, occupancy = true, StadiumId = 1, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies = new List<Lobby>() },
                new Time_Slot { Id = 2, occupancy = false, StadiumId = 2, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies = new List<Lobby>() },
                new Time_Slot { Id = 3, occupancy = false, StadiumId = 3, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30), LinkedLobbies = new List<Lobby>() },
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