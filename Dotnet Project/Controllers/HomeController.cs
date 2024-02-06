using System.Diagnostics;
using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Dotnet_Project.Utility;
using Dotnet_Project.Models.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger , AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(SD.Role_Player))
            {
                var loggedInPlayerId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ApplicationUser loggedInPlayer = _context.Users.FirstOrDefault(p => p.Id == loggedInPlayerId);

                if (loggedInPlayer.Notification)
                {
                    TempData["error2"] = "Your lobby was removed";
                    loggedInPlayer.Notification = false;
                    _context.SaveChanges();
                }
            
                return View();
            }
                
            else if (User.IsInRole(SD.Role_Stade_Owner))
                return RedirectToAction("MyStadium", "Profile");
            else
                return RedirectToAction("Welcome");
        }


        public IActionResult Welcome() 
        {
            return View(); 
        }



        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}