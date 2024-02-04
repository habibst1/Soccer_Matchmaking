using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CreateLobbyViewModel
{
    [Required(ErrorMessage = "Please enter a lobby name.")]
    public string LobbyName { get; set; }

    [Required(ErrorMessage = "Please select a stadium.")]
    public int StadiumId { get; set; }

    [Required(ErrorMessage = "Please select a time slot.")]
    public int TimeSlotId { get; set; }

    [Required(ErrorMessage = "Please select players.")]
    public List<string> SelectedPlayerIds { get; set; }
}
