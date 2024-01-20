using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class Stade_Owner
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        [ForeignKey("Stade")]
        public int StadeId { get; set; }
        public Stadium stade { get; set; }

        public string EMail { get; set; }
        public string mdp { get; set; }

        public Stade_Owner(string email, string mdp, string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
            this.EMail = email;
            this.mdp = mdp;
            this.stade = null;
        }

        public void createStadium(string name, string description, string localisation, string phtopath)
        {
            if (this.stade == null)
            {
                Stadium S = new Stadium(name, description, localisation, phtopath);
                this.stade = S;
                this.StadeId = S.Id;
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

