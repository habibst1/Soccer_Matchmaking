using Dotnet_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dotnet_Project.Controllers
{
    public class ProfileController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;


        public ProfileController(AppDbContext context , UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            // Retrieve the logged-in player */
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return Redirect("/Identity/Account/Login"); // Redirect to login or handle it accordingly
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
        public IActionResult MyStadium()
        {
            return View();
        }
		public IActionResult Welcome()
		{
			return View();
		}
	}
}
