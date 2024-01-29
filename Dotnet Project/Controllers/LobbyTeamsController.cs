using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Specialized;

public class LobbyTeamsController : Controller
{
    private readonly AppDbContext _context;

    public LobbyTeamsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: /LobbyTeams/Create
    public IActionResult Create()
    {
        // Retrieve all stadiums
        var allStadiums = _context.Stadiums.ToList();

        // Pass all stadiums to the view
        ViewBag.Stadiums = new SelectList(allStadiums, "Id", "Name");

        //HEDHI COMMENTED 5ATER MARAKA7NACH LOGIN
        /* Retrieve the currently logged-in player (admin)      UPPPP: Hedhi na3mloha ba3d manrak7ou Login wkol donc chna3mel 
         wa7da depannage ta7tha
       
         var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

        if (adminPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }
      
        // Retrieve available players (excluding the admin player)
        var availablePlayers = _context.Players
            .Where(p => p.LinkedLobby == null && p.ID != int.Parse(adminPlayerId))
            .ToList();

        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(availablePlayers, "ID", "Name");
      */
        //HEDHI JUST TA3WIDH LELLI FO9HA 
        var availablePlayers = _context.Players
            .Where(p => p.LinkedLobby == null)
            .ToList();

        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(availablePlayers, "ID", "Name");

        return View();
    }

    // GET: /LobbyTeams/GetTimeSlots?stadiumId={stadiumId}
    [HttpGet]
    public IActionResult GetTimeSlots(int stadiumId)
    {
        // Retrieve time slots for the selected stadium
        var timeSlots = _context.TimeSlots
            .Where(t => t.StadiumId == stadiumId && !t.occupancy)
            .ToList();

        // Return a partial view with the time slots
        return PartialView("_TimeSlotOptionsPartial", timeSlots);
    }

    // POST: /LobbyTeams/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string lobbyName, int stadiumId, int timeSlotId, List<int> selectedPlayerIds)
    {
        // Add validation for lobbyName, stadiumId, timeSlotId, and selectedPlayerIds as needed

        // Retrieve selected stadium and time slot
        var selectedStadium = _context.Stadiums
            .Include(s => s.Times)
            .ThenInclude(t => t.LinkedLobbies)
            .FirstOrDefault(s => s.Id == stadiumId);

        var selectedTimeSlot = selectedStadium?.Times.FirstOrDefault(t => t.Id == timeSlotId);

        // Check if the selected stadium and time slot are valid
        if (selectedStadium == null || selectedTimeSlot == null || selectedTimeSlot.occupancy)
        {
            // Handle invalid selection, perhaps redirect to the create page with an error message
            return RedirectToAction("Create");
        }
       /*KIFKIF HEDHI COMMETED 5ATER LOGIN
        // Retrieve the currently logged-in player (admin)
        var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"
        
        if (adminPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }
        
        var adminPlayer = _context.Players.FirstOrDefault(p => p.ID == int.Parse(adminPlayerId));
       */ 
        // Retrieve selected players
        var selectedPlayers = _context.Players
            .Where(p => selectedPlayerIds.Contains(p.ID))
            .ToList();

        // Check if the number of selected players is valid
        if (selectedPlayers.Count != 6)
        {
            // Handle invalid number of players, perhaps redirect to the create page with an error message
            return RedirectToAction("Create");
        }
       
        // Create lobby and join players using CreateLobby method
        //ELLI COMMENTED TA7T HEDHA HIYA LSHIHA AMA 5ATER EL LOGIN AHAYKA 3ALA JNAB
        //var newLobby = adminPlayer.CreateLobby(selectedTimeSlot, selectedPlayers, lobbyName, "LobbyTeam");
       
        var newLobby = new Lobby(lobbyName, selectedTimeSlot,"LobbyTeam");
        
        foreach (var player in selectedPlayers)
        {
            player.JoinLobby(newLobby);
        }

        //NA7IW EL LOBBIAT ELLI DEJA MARBOUTIN B TIMESLOT KAN LOBBY MTA3NA T3ABBA
        if (newLobby.IsFull)
        {
            newLobby.TimeSlot.occupancy = true;

            var linkedLobbiesCopy = new List<Lobby>(newLobby.TimeSlot.LinkedLobbies);

            for (int i = 0; i < linkedLobbiesCopy.Count; i++)
            {
                Lobby otherlobby = linkedLobbiesCopy[i];

                if (otherlobby != newLobby)
                {
                    var linkedPlayers = _context.Players.Where(p => p.LinkedLobbyId == otherlobby.Id).ToList();

                    foreach (var player in linkedPlayers)
                    {
                        player.LinkedLobbyId = null; // or assign to another lobby if needed
                    }

                    newLobby.TimeSlot.LinkedLobbies.Remove(otherlobby);

                    _context.Lobbies.Remove(otherlobby);
                }
            }

        }


        if (newLobby != null)
        {
            // Add the new lobby to the database context
            _context.Lobbies.Add(newLobby);

            // Save changes to the database
            _context.SaveChanges();

            // Redirect to the home page or another appropriate page
            return RedirectToAction("Index", "Home");
        }
        else
        {
            // Handle the case where the lobby creation fails
            return RedirectToAction("Create");
        }
    }


    public IActionResult Join()
    {
        //HEDHI COMMENTED 5ATER MARAKA7NACH LOGIN
        /* Retrieve the currently logged-in player (admin)      UPPPP: Hedhi na3mloha ba3d manrak7ou Login wkol donc chna3mel 
         wa7da depannage ta7tha
       
         var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

        if (adminPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }
      
        // Retrieve available players (excluding the admin player)
        var availablePlayers = _context.Players
            .Where(p => p.LinkedLobby == null && p.ID != int.Parse(adminPlayerId))
            .ToList();

        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(availablePlayers, "ID", "Name");
      */
        //HEDHI JUST TA3WIDH LELLI FO9HA
        var availablePlayers = _context.Players
            .Where(p => p.LinkedLobby == null)
            .ToList();

        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(availablePlayers, "ID", "Name");

        return View();
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Join(List<int> selectedPlayerIds)
    {
        /*KIFKIF HEDHI COMMETED 5ATER LOGIN
        // Retrieve the currently logged-in player (admin)
        var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

        if (adminPlayerId == null)
        {
           // Handle the case where the user is not logged in
           return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        var adminPlayer = _context.Players.FirstOrDefault(p => p.ID == int.Parse(adminPlayerId));
        */

        // Retrieve selected players
        
        // Check if the number of selected players is valid
        if (selectedPlayerIds.Count != 6)
        {
            // Handle invalid number of players, perhaps redirect to the create page with an error message
            return RedirectToAction("Join");
        }


        return RedirectToAction("AvailableLobbies", new {selectedPlayerIds = selectedPlayerIds});
    }

    public IActionResult AvailableLobbies(List<int> selectedPlayerIds)
    {
        /*KI YARKA7 EL LOGIN
        // Retrieve the logged-in player
        var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (loggedInPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        var loggedInPlayer = _context.Players.FirstOrDefault(p => p.ID == int.Parse(loggedInPlayerId));

        if (loggedInPlayer == null)
        {
            // Handle the case where the logged-in player is not found
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        if(loggedInPlayer.LinkedLobby)
        {
          lazem maynjmch yenzel 3ala Join Lobby men aslou
        }
        */
        

        ///////////lazemni nzid condition tthabet mel joueret linedlobby t3hom 0 sinn iji wa7ed i7t fel url ay id mta3 joueur w mchéna feha 


        // Retrieve available lobbies that the player can join
        var availableLobbies = _context.Lobbies
            .Include(l => l.Players)
            .Include(l => l.TimeSlot)
            .Include(l => l.TimeSlot.stadium)
            .Where(l => l.Type == "LobbyTeam" && !l.IsFull && !l.IsFinished && l.Players.Count < 7)
            .ToList();

       JoinLobbyViewModel test= new JoinLobbyViewModel(availableLobbies , selectedPlayerIds);

        return View(test);
    }

    [HttpPost]
    public IActionResult AvailableLobbies(int lobbyId , List<int> selectedPlayersIDs)
    {

        var selectedPlayers = _context.Players
             .Where(p => selectedPlayersIDs.Contains(p.ID))
             .ToList();

        var selectedLobby = _context.Lobbies.Include(l => l.Players).Include(t => t.TimeSlot).Include(l => l.TimeSlot.LinkedLobbies).FirstOrDefault(l => l.Id == lobbyId);



        foreach (var player in selectedPlayers)
        {   
            player.JoinLobby(selectedLobby);
        }

        if (selectedLobby.IsFull)
        {
            selectedLobby.TimeSlot.occupancy = true;

            var linkedLobbiesCopy = new List<Lobby>(selectedLobby.TimeSlot.LinkedLobbies);

            for (int i = 0; i < linkedLobbiesCopy.Count; i++)
            {
                Lobby otherlobby = linkedLobbiesCopy[i];

                if (otherlobby != selectedLobby)
                {
                    var linkedPlayers = _context.Players.Where(p => p.LinkedLobbyId == otherlobby.Id).ToList();

                    foreach (var player in linkedPlayers)
                    {
                        player.LinkedLobbyId = null; // or assign to another lobby if needed
                    }

                    selectedLobby.TimeSlot.LinkedLobbies.Remove(otherlobby);

                    _context.Lobbies.Remove(otherlobby);
                }
                
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return RedirectToAction("AvailableLobbies");
        }


        
    }




}
