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

        public int prix { get; set; }

        public int nbminutes { get; set; }

        [Required]
        [NotMapped]
        public IFormFile PhotoStade { get; set; }

        [Required]
        [NotMapped]
        public IFormFile PhotoStade2 { get; set; }


            public List<Time_Slot>? Times { get; set; }


            public Stadium()
             {
                    this.Times = new List<Time_Slot>();
             }
           
            public Stadium(string name, string description, string localisation, string exactlocalisation, string photopath , string photopath2 , int prix , int nbminutes)
            {
                this.Name = name;
                this.Description = description;
                this.Localisation = localisation;
                this.exactLocalisation = exactlocalisation;
                this.PhotoPath = photopath;
                this.PhotoPath2 = photopath2;
                this.prix = prix;
                this.nbminutes = nbminutes;
                Times = new List<Time_Slot>();
            }
        }
    }
