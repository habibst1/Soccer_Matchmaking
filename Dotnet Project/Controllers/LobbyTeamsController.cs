using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

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

        // Retrieve the currently logged-in player (admin)
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

        // Retrieve the currently logged-in player (admin)
        var adminPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

        if (adminPlayerId == null)
        {
            // Handle the case where the user is not logged in
            return RedirectToAction("Login"); // Redirect to login or handle it accordingly
        }

        var adminPlayer = _context.Players.FirstOrDefault(p => p.ID == int.Parse(adminPlayerId));

        // Retrieve selected players
        var selectedPlayers = _context.Players
            .Where(p => selectedPlayerIds.Contains(p.ID))
            .ToList();

        // Check if the number of selected players is valid
        if (selectedPlayers.Count != 5)
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
}
