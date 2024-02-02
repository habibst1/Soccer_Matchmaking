namespace Dotnet_Project.Models
{
    public class ProfileViewModel
    {
        public List<Lobby>? lobbies { get; set; }

        public ApplicationUser loggedInPlayer { get; set; }

        public ProfileViewModel(List<Lobby> lobbies, ApplicationUser loggedinPlayer)
        {
            this.lobbies = lobbies;
            this.loggedInPlayer = loggedinPlayer;

        }
    }
}
