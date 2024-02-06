namespace Dotnet_Project.Models.ViewModels
{
    public class ProfileViewModel
    {
        public List<Lobby>? lobbies { get; set; }

        public ApplicationUser loggedInPlayer { get; set; }

        public Dictionary<string, string> Team1Names { get; set; }

        public Dictionary<string, string> Team2Names { get; set; }

        public ProfileViewModel(List<Lobby> lobbies, ApplicationUser loggedinPlayer , Dictionary<string, string> team1Names, Dictionary<string,string> team2Names)
        {
            this.lobbies = lobbies;
            loggedInPlayer = loggedinPlayer;
            this.Team1Names = team1Names;
            this.Team2Names = team2Names;

        }
    }
}
