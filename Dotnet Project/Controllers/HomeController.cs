using System.Diagnostics;
using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Dotnet_Project.Utility;

namespace Dotnet_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (User.IsInRole(SD.Role_Player))
                return View();
            else if (User.IsInRole(SD.Role_Stade_Owner))
                return RedirectToAction("Index", "Profile");
            else
                return Redirect("/Identity/Account/Login");
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