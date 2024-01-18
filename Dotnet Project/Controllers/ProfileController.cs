using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Project.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
