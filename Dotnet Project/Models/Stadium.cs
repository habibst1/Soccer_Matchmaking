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

            public string exactLocalisation { get; set; }

            public string PhotoPath { get; set; }

            public string PhotoPath2 { get; set; }

            public List<Time_Slot>? Times { get; set; }


            public Stadium() 
            {
                Times = new List<Time_Slot>();
            }
            public Stadium(string name, string description, string localisation, string exactlocalisation,string photopath , string photopath2)
            {
                this.Name = name;
                this.Description = description;
                this.Localisation = localisation;
                this.exactLocalisation = exactlocalisation;
                this.PhotoPath = photopath;
                this.PhotoPath2 = photopath2;
                Times = new List<Time_Slot>();
            }
        }
    }
