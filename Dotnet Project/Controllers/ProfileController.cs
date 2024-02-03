using Dotnet_Project.Models;
using Dotnet_Project.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Security.Claims;

namespace Dotnet_Project.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;
        private readonly ImageHelper _imageHelper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfileController(AppDbContext context , UserManager<IdentityUser> userManager , IWebHostEnvironment webHostEnvironment, ImageHelper imageHelper)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
            _imageHelper = imageHelper;
        }


        public async Task<IActionResult> Index()
        {
            // Retrieve the logged-in player
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = await _userManager.FindByIdAsync(loggedInPlayerId);

            if (loggedInPlayer == null)
            {
                // Handle the case where the user is not found
                return NotFound();
            }

            // Check if the logged-in player has the role "Player"
            var isPlayer = await _userManager.IsInRoleAsync(loggedInPlayer, "Player");

            if (isPlayer)
            {
                // Perform actions specific to the "Player" role
                // For example, redirect to a player dashboard
                return RedirectToAction("MyProfile");
            }
            else
            {
                return RedirectToAction("MyStadium");
            }
        }



        [Authorize(Roles = SD.Role_Player)]
        public IActionResult MyProfile()
        {

            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }


            var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby)
                                                    .ThenInclude(t => t.TimeSlot).
                                                            ThenInclude(s => s.stadium)
                                               .Include(a => a.LinkedLobby)
                                                    .ThenInclude(l => l.Team1)
                                               .Include(a => a.LinkedLobby)
                                                    .ThenInclude(l => l.Team2)
                                               .FirstOrDefault(p => p.Id == loggedInPlayerId);


            var lobbieshistory = _context.Lobbies.Include(p => p.Team1).Include(p => p.Team2).Include(t => t.TimeSlot).ThenInclude(s => s.stadium)
                                 .Where(lobby => lobby.Players.Any(player => player.Id == loggedInPlayerId) && lobby.IsFinished)
                                 .ToList();



            ProfileViewModel profile = new ProfileViewModel(lobbieshistory, loggedInPlayer);

            return View(profile);
        }


        [Authorize(Roles = SD.Role_Stade_Owner)]
        public IActionResult MyStadium()
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(t => t.Times).FirstOrDefault( p => p.Id == loggedInPlayerId);



            return View(loggedInPlayer);
        }


        [Authorize(Roles = SD.Role_Stade_Owner)]
        [HttpPost]
        public IActionResult Create(Stadium stadium)
        {

            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(s => s.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);


            string photoFileName = _imageHelper.SaveStadiumPhoto(stadium.PhotoPath);
            stadium.PhotoPath = photoFileName;

            Stadium stade = loggedInPlayer.createStadium(stadium.Name, stadium.Description, stadium.Localisation, stadium.exactLocalisation, stadium.PhotoPath, stadium.PhotoPath2, stadium.prix, stadium.nbminutes);

            _context.Stadiums.Add(stade);
            _context.SaveChanges();
                
            return RedirectToAction("MyStadium");
        }



        [Authorize(Roles = SD.Role_Stade_Owner)]
        [HttpPost]
        public IActionResult AddTimeSlot(DateTime date , string starttime , string endtime)
        {
            // Retrieve the logged-in player 
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var loggedInPlayer = _context.Users.Include(s => s.stade).ThenInclude(s => s.Times).FirstOrDefault(p => p.Id == loggedInPlayerId);

            // Parse the input strings to DateTime
            DateTime startDateTime = DateTime.Parse($"{date.ToShortDateString()} {starttime}");
            DateTime endDateTime = DateTime.Parse($"{date.ToShortDateString()} {endtime}");

            var timeSlot = new Time_Slot(loggedInPlayer.stade , startDateTime, endDateTime);
            loggedInPlayer.add_time_slot(timeSlot);

            _context.TimeSlots.Add(timeSlot);
            _context.SaveChanges();

            return RedirectToAction("MyStadium");
        }

	}
}
