using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class ApplicationUser : IdentityUser
    {
        /* Things for Player */
        public string? PhotoPath { get; set; }
        public string? Adress {  get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int number_wins { get; set; }
        public int number_losses { get; set; }
        public int number_draws { get; set; }

        public int? LinkedLobbyId { get; set; }
        public Lobby? LinkedLobby { get; set; }

        public int TeamNumber { get; set; } // Add a property to specify the team number


        public bool IsAdmin { get; set; }


        public Lobby CreateLobby(Time_Slot t, List<ApplicationUser> players, string Name, string type)
        {
            if (this.LinkedLobby == null && !t.occupancy)
            {
                Lobby L = new Lobby(Name, t, type);

                this.IsAdmin = true;

                this.JoinLobby(L);

                if(players != null) { 
                    foreach (ApplicationUser player in players)
                    {
                    player.JoinLobby(L);
                    }
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

                if (L.Players.Count() < 6)
                {
                    this.TeamNumber = 1;
                    L.Players.Add(this);
                    
                }
                else if (L.Players.Count() < 12)
                {
                    this.TeamNumber = 2;
                    L.Players.Add(this);
                    if (L.Players.Count() == 12) L.IsFull = true;
                }

                
            }
        }




        /* Things For Stade Owner*/
        public int? StadeId { get; set; }
        public Stadium? stade { get; set; }

        public Stadium createStadium(string name, string description, string localisation, string exactlocalisation, string phtopath, string photopath2 , int prix , int nbminutes)
        {
            if (this.stade == null)
            {
                Stadium S = new Stadium(name, description, localisation, exactlocalisation, phtopath, photopath2 , prix , nbminutes);
                this.stade = S;
                this.StadeId = S.Id;
                return (S);
            }
            else
            {
                return null;
            }
            

        }

        public void add_time_slot(Time_Slot t)
        {
            stade.Times.Add(t);

        }

        public void remove_time_slot(Time_Slot t)
        {
            stade.Times.Remove(t);

        }
    }
}