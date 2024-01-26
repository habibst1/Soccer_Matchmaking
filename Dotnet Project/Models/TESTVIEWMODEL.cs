namespace Dotnet_Project.Models
{
    public class JoinLobbyViewModel
    {
        public List<Lobby> lobbies {  get; set; }

        public List<int> playerids { get; set; }

        public JoinLobbyViewModel(List<Lobby> lobbies , List<int> playerids) {
            this.lobbies = lobbies;
            this.playerids = playerids;
        }
    }
}
