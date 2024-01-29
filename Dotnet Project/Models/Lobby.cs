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

        public int TimeSlotId { get; set; }
        public Time_Slot TimeSlot { get; set; }

        public List<Player> Players { get; set; } // Consolidated list for all players in the lobby

        public List<Player> Team1 => Players.Where(p => p.TeamNumber == 1).ToList();

        public List<Player> Team2 => Players.Where(p => p.TeamNumber == 2).ToList();


        public string Type { get; set; }
        public bool IsFull { get; set; }
        public bool IsFinished { get; set; }

        public Lobby()
        {   
            Players = new List<Player>();
        }

        public Lobby(string name, Time_Slot t, string type)
        {
            this.Name = name;
            this.TimeSlot = t;
            this.Type = type;
            this.IsFull = false;
            this.IsFinished = false;
            this.Players = new List<Player>();
        }

           //FAZAT L REMOVE N7OTTOUHOM FEL CONTROLLER W BARRA
 
    }
}   