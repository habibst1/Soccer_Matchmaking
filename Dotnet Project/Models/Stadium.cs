using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class Stadium
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Localisation { get; set; }
        public string PhotoPath { get; set; }

        public List<Time_Slot> Times { get; set; }

        public Stadium(string name, string description, string localisation, string photopath)
        {
            this.Name = name;
            this.Description = description;
            this.Localisation = localisation;
            this.PhotoPath = photopath;
            Times = new List<Time_Slot>();
        }
    }
}
