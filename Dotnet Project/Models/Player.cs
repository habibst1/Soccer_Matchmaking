using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }

        public string EMail { get; set; }
        public string mdp { get; set; }
        public string PhotoPath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int number_wins { get; set; }
        public int number_losses { get; set; }
        public int number_draws { get; set; }

        [ForeignKey("LinkedLobbyId")]
        public int? LinkedLobbyId { get; set; }
        public Lobby LinkedLobby { get; set; }

        public bool IsAdmin { get; set; }

        public Player(string email, string mdp, string name, string surname, string photopath)
        {
            this.EMail = email;
            this.mdp = mdp;
            this.Name = name;
            this.Surname = surname;
            this.PhotoPath = photopath;
            this.number_wins = 0;
            this.number_losses = 0;
            this.number_draws = 0;
            this.IsAdmin = false;
            this.LinkedLobby = null;
        }

        public Lobby CreateLobby(Time_Slot t, List<Player> players, string Name, string type)
        {
            if (this.LinkedLobby == null && !t.occupancy)
            {
                Lobby L = new Lobby(Name, t, type);

                this.IsAdmin = true;

                foreach (Player player in players)
                {
                    player.JoinLobby(L);
                }
                return (L);
            }
            else return (null);
        }

        public void JoinLobby(Lobby L)
        {
            if (this.LinkedLobby == null)
            {
                this.LinkedLobby = L;

                if (L.Team1.Count() < 7)
                    L.Team1.Add(this);
                else if (L.Team2.Count() < 7)
                {
                    L.Team2.Add(this);
                    if (L.Team2.Count() == 6) L.IsFull = true;
                }

                if (L.IsFull)
                {
                    L.t.occupancy = true;
                    foreach (Lobby otherlobby in L.t.LinkedLobbies)
                    {
                        if (!otherlobby.t.occupancy)
                            otherlobby.remove_lobby();
                    }
                }
            }
        }
    }
}