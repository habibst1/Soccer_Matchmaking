using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnet_Project.Models
{
    public class Time_Slot
    {
        [Key]
        public int Id { get; set; }
        public bool occupancy { get; set; }

        [ForeignKey("Stadium")]
        public int StadiumId { get; set; }
        public Stadium stadium { get; set; }

        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }

        public List<Lobby> LinkedLobbies { get; set; }

        public Time_Slot(Stadium stadium, DateTime hour)
        {
            this.stadium = stadium;
            this.start_time = hour;
            this.end_time = hour.AddHours(1).AddMinutes(30);
            this.LinkedLobbies = new List<Lobby>();
            this.occupancy = false;
        }

        public void remove_time_slot()
        {
            
        }

        public string get_match_time()
        {
            string formattedTimeRange = $"{start_time:HH:mm} --> {end_time:HH:mm}";
            return formattedTimeRange;
        }
    }
}
