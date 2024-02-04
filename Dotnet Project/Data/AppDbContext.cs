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

            modelBuilder.Entity<Lobby>()
                .HasMany(l => l.Players);

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

            // Seed Players
          /*  modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Name = "Ala", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Taher", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Habib", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Fedy", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Najar", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Reb3i", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Ghazi", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Kamel", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Karim", Surname = "Doe", PhotoPath = "path2", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Samir", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Kais", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Aziz", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Youssef", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Hamza", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Ali", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Mustafa", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Elyess", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Omar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Ismail", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Amine", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Talel", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Yahya", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Skander", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Omar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Zahran", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Mohamed", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Fethi", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Adem", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Ahmed", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Ayhem", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Abderrahmen", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Hamdi", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Majd", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Bachar", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null },
                new ApplicationUser { Name = "Oussama", Surname = "Doe", PhotoPath = "path1", number_wins = 0, number_losses = 0, number_draws = 0, IsAdmin = false, LinkedLobbyId = null }
            // Add more players as needed
            );
          */

            // Seed Stadiums
          /*  modelBuilder.Entity<Stadium>().HasData(
                new Stadium { Id = 1, Name = "May Land", Description = "CHOUF 3CHIRI A9WA STADE F TUNIS KAMLA W YOUFA LA7DITH", Localisation = "Monastir", exactLocalisation = "https://maps.app.goo.gl/qfwmuN7oYvZAHxgo6", PhotoPath = "Images/StadeMay.png", PhotoPath2 = "Images/StadeMay2.png" },
                new Stadium { Id = 2, Name = "Five Stars", Description = "A9WA STADE FEL 3ASSMA", Localisation = "Route De Sidi Younes El Borj", exactLocalisation = "https://maps.app.goo.gl/JuCkdWuti8xPFwsE9", PhotoPath = "Images/StadeFive.png", PhotoPath2 = "/Images/StadeFive2.png" },
                new Stadium { Id = 3, Name = "Stade Charguia", Description = "A5YEB STADE F TUNIS KAMLA", Localisation = "Charguia", exactLocalisation = "https://maps.app.goo.gl/SYJ6qQaWXY9MkE7XA", PhotoPath = "Images/StadeCharguia.png", PhotoPath2 = "Images/StadeCharguia2.png" },
                new Stadium { Id = 4, Name = "MStadium", Description = "AWEL STADE F MAHDIA", Localisation = "Mahdia", exactLocalisation = "https://maps.app.goo.gl/k5BGdbc26YHUTnsy6", PhotoPath = "Images/MStadium.png", PhotoPath2 = "Images/MStadium2.png" },
                new Stadium { Id = 5, Name = "Parc Des Princes", Description = "A7SSEN STADE F MAHDIA", Localisation = "Rejiche", exactLocalisation = "https://maps.app.goo.gl/YqEoZrBDytUnh2Te9", PhotoPath = "Images/PDP.png", PhotoPath2 = "Images/PDP2.png" },
                new Stadium { Id = 6, Name = "Al Kahna", Description = "STADE F WOST 7OMMA T5AWEF ", Localisation = "Monastir", exactLocalisation = "https://maps.app.goo.gl/pHnjSerugXFYSRE39", PhotoPath = "Images/Kahna.png", PhotoPath2 = "Images/Kahna2.png" },
                new Stadium { Id = 7, Name = "Stade Sahara Beach", Description = "EKTICHAF JDID", Localisation = "Monastir", exactLocalisation = "https://maps.app.goo.gl/UGkynYQKBK7Mai9U6", PhotoPath = "Images/Sahara.png", PhotoPath2 = "Images/Sahara2.png" }
            );
          */

/*
            // Seed Time Slots
            modelBuilder.Entity<Time_Slot>().HasData(
                new Time_Slot { Id = 1, occupancy = true, StadiumId = 1, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30) },
                new Time_Slot { Id = 2, occupancy = false, StadiumId = 2, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30) },
                new Time_Slot { Id = 3, occupancy = false, StadiumId = 3, start_time = DateTime.Now, end_time = DateTime.Now.AddHours(1).AddMinutes(30) },
                new Time_Slot { Id = 4, occupancy = false, StadiumId = 1, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30) },
                new Time_Slot { Id = 5, occupancy = false, StadiumId = 2, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30) },
                new Time_Slot { Id = 6, occupancy = false, StadiumId = 3, start_time = DateTime.Now.AddHours(2), end_time = DateTime.Now.AddHours(3).AddMinutes(30) }
            // Add more time slots as needed
            );


            // Seed Stade Owners
            /*modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Name = "Owner1", Surname = "Owner1Surname" },
                new ApplicationUser {Name = "Owner2", Surname = "Owner2Surnam" }
            // Add more stade owners as needed
            );
            */

            base.OnModelCreating(modelBuilder);
        }

    }
}