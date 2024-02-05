using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dotnet_Project.Utility;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Dotnet_Project.Models.ViewModels;

[Authorize(Roles = SD.Role_Player)]
public class LobbyTeamsController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _context;

    public LobbyTeamsController(AppDbContext context , UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: /LobbyTeams/Create
    public  IActionResult Create()
    {
        // Retrieve all stadiums
        var allStadiums = _context.Stadiums.ToList();

        // Pass all stadiums to the view
        ViewBag.Stadiums = new SelectList(allStadiums, "Id", "Name");

       
        //Retrieve the currently logged-in player (admin)
       
        var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

        var adminPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == adminPlayerId);

        if (adminPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
        }

        if (adminPlayer.LinkedLobby != null)
        {
            TempData["error"] = "You are already linked to a lobby";
            return RedirectToAction("Index", "Home"); 
           
        }
        // Retrieve available players (excluding the admin player)
        var availablePlayers = _context.Users
                                .Where(p => p.LinkedLobby == null && p.Id != adminPlayerId)
                                .ToList();

        // Filter the results in memory (client-side) using LINQ to Objects
        var filteredPlayers = availablePlayers.Where(p => _userManager.IsInRoleAsync(p, "Player").Result).ToList();



        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(filteredPlayers, "Id", "Name");

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
    public IActionResult Create(string lobbyName, int stadiumId, int timeSlotId, List<string> selectedPlayerIds)
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
   
        // Retrieve the currently logged-in player (admin)
        
        var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"
        
        
        var adminPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == adminPlayerId);
       
        // Retrieve selected players
        var selectedPlayers = _context.Users
            .Where(p => selectedPlayerIds.Contains(p.Id))
            .ToList();

        // Check if the number of selected players is valid
        if (selectedPlayers.Count() != 5)
        {
            // Handle invalid number of players, perhaps redirect to the create page with an error message
            return RedirectToAction("Create");
        }
       
        // Create lobby and join players using CreateLobby method
       
        
        var newLobby = adminPlayer.CreateLobby(selectedTimeSlot, selectedPlayers, lobbyName, "LobbyTeam");
       
  
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
        
        // Retrieve the currently logged-in player (admin)
       
         var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

         var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

        if  (loggedInPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        if (loggedInPlayer.LinkedLobby != null)
        {
            TempData["error"] = "You are already linked to a lobby";
            return RedirectToAction("Index", "Home");
            
        }
        // Retrieve available players (excluding the admin player)
        var availablePlayers = _context.Users
            .Where(p => p.LinkedLobby == null && p.Id != loggedInPlayerId)
            .ToList();

        // Filter the results in memory (client-side) using LINQ to Objects
        var filteredPlayers = availablePlayers.Where(p => _userManager.IsInRoleAsync(p, "Player").Result).ToList();



        // Pass available players to the view
        ViewBag.AvailablePlayers = new MultiSelectList(filteredPlayers, "Id", "Name");

        return View();

    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Join(List<string> selectedPlayerIds)
    {
        // Retrieve selected players
        
        // Check if the number of selected players is valid
        if (selectedPlayerIds.Count != 5)
        {
            // Handle invalid number of players, perhaps redirect to the create page with an error message
            return RedirectToAction("Join");
        }


        return RedirectToAction("AvailableLobbies", new {selectedPlayerIds = selectedPlayerIds});
    }

    public IActionResult AvailableLobbies(List<string> selectedPlayerIds)
    {
        // Retrieve the logged-in player */
        var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        if (loggedInPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

        if (loggedInPlayer == null)
        {
            // Handle the case where the logged-in player is not found
            return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
        }

        if (loggedInPlayer.LinkedLobby != null)
        {
            TempData["error"] = "You are already linked to a lobby";
            return RedirectToAction("Index", "Home");
          
        }


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
    public IActionResult AvailableLobbies(int lobbyId , List<string> selectedPlayersIDs)
    {

        var selectedPlayers = _context.Users
             .Where(p => selectedPlayersIDs.Contains(p.Id))
             .ToList();

        var selectedLobby = _context.Lobbies.Include(l => l.Players).Include(t => t.TimeSlot).Include(l => l.TimeSlot.LinkedLobbies).FirstOrDefault(l => l.Id == lobbyId);

        var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var loggedInPlayer = _context.Users.FirstOrDefault(p => p.Id == loggedInPlayerId);


        loggedInPlayer.JoinLobby(selectedLobby);

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
                    var linkedPlayers = _context.Users.Where(p => p.LinkedLobbyId == otherlobby.Id).ToList();

                    foreach (var player in linkedPlayers)
                    {
                        player.LinkedLobbyId = null;
                        otherlobby.admin = null;    
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
