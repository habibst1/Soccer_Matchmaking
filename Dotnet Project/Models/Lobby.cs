using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class Lobby
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }
        public Time_Slot t { get; set; }

        public List<Player> Team1 { get; set; }
        public List<Player> Team2 { get; set; }

        public string Type { get; set; }
        public bool IsFull { get; set; }
        public bool IsFinished { get; set; }

        public Lobby(string name, Time_Slot t, string type)
        {
            this.Name = name;
            this.t = t;
            this.Type = type;
            this.IsFull = false;
            this.IsFinished = false;
            this.Team1 = new List<Player>();
            this.Team2 = new List<Player>();
            this.t.LinkedLobbies.Add(this);
        }

        public void remove_players()
        {
            foreach (Player p in Team1)
            {
                p.LinkedLobby = null;
            }

            foreach (Player p in Team2)
            {
                p.LinkedLobby = null;
            }
        }

        public void remove_lobby()
        {
            this.remove_players();
            this.t.LinkedLobbies.Remove(this);
        }

        public void update_isFinished()
        {
            this.remove_players();
            this.t.remove_time_slot();
        }
    }
}