namespace Dotnet_Project.Models.ViewModels
{
    public class ProfileViewModel
    {
        public List<Lobby>? lobbies { get; set; }

        public ApplicationUser loggedInPlayer { get; set; }

        public Dictionary<string, string> PlayerNames { get; set; }

        public ProfileViewModel(List<Lobby> lobbies, ApplicationUser loggedinPlayer , Dictionary<string, string> playerNames)
        {
            this.lobbies = lobbies;
            loggedInPlayer = loggedinPlayer;
            this.PlayerNames = playerNames;

        }
    }
}
