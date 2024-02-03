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

[Authorize(Roles = SD.Role_Player)]
public class LobbySoloController : Controller
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppDbContext _context;

    public LobbySoloController(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // GET: /LobbySolo/Create
    public IActionResult Create()
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

        if (adminPlayer.LinkedLobby != null) return RedirectToAction("Index", "Home"); // w maaha error (you are already in a lobby)


        return View();

    }


    // GET: /LobbySolo/GetTimeSlots?stadiumId={stadiumId}
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

    // POST: /LobbySolo/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string lobbyName, int stadiumId, int timeSlotId)
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


        // Create lobby and join players using CreateLobby method


        var newLobby = adminPlayer.CreateLobby(selectedTimeSlot, null , lobbyName, "LobbySolo");


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


    public IActionResult AvailableLobbies()
    {
        // Retrieve the logged-in player */
        var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


        if (loggedInPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
        }

        var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);



        if (loggedInPlayer.LinkedLobby != null)   return  RedirectToAction("Index", "Home"); //w maaha error (you are already in a lobby)
        

        // Retrieve available lobbies that the player can join
        var availableLobbies = _context.Lobbies
            .Include(l => l.Players)
            .Include(l => l.TimeSlot)
            .Include(l => l.TimeSlot.stadium)
            .Where(l => l.Type == "LobbySolo" && !l.IsFull && !l.IsFinished && l.Players.Count < 12)
            .ToList();

        JoinLobbyViewModel test = new JoinLobbyViewModel(availableLobbies, null);

        return View(test);
    }

    [HttpPost]
    public IActionResult AvailableLobbies(int lobbyId)
    {

        var selectedLobby = _context.Lobbies.Include(l => l.Players).Include(t => t.TimeSlot).Include(l => l.TimeSlot.LinkedLobbies).FirstOrDefault(l => l.Id == lobbyId);

        var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var loggedInPlayer = _context.Users.FirstOrDefault(p => p.Id == loggedInPlayerId);


        loggedInPlayer.JoinLobby(selectedLobby);


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
                        if (player.IsAdmin) player.IsAdmin = false;

                    }

                    selectedLobby.TimeSlot.LinkedLobbies.Remove(otherlobby);

                    _context.Lobbies.Remove(otherlobby);
                }

            }
        }
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }




}
