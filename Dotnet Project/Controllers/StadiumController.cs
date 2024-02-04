using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Dotnet_Project.Controllers
{
    public class StadiumController : Controller
    {

        private readonly AppDbContext _context;

        public StadiumController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

            var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var  allstadiums  = _context.Stadiums.ToList();


            return View(allstadiums);
        }

        public IActionResult Details(int id)
        {


            var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Assuming ID is stored in "ClaimTypes.NameIdentifier"

            var loggedInPlayer = _context.Users.Include(a => a.LinkedLobby).FirstOrDefault(p => p.Id == loggedInPlayerId);

            if (loggedInPlayerId == null)
            {
                // Handle the case where the user is not logged in
                return RedirectToAction("Welcome", "Home"); // Redirect to login or handle it accordingly
            }

            var stadium = _context.Stadiums.Include(s => s.Times).FirstOrDefault(st => st.Id == id);

            if (stadium == null)
            {
                return RedirectToAction("Index");
            }

            return View(stadium);
        }
    }
}
