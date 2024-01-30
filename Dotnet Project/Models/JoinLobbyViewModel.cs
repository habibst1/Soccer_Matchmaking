namespace Dotnet_Project.Models
{
    public class JoinLobbyViewModel
    {
        public List<Lobby> lobbies {  get; set; }

        public List<string> playerids { get; set; }

        public JoinLobbyViewModel(List<Lobby> lobbies , List<string> playerids) {
            this.lobbies = lobbies;
            this.playerids = playerids;
        }
    }
}
