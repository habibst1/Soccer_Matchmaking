using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Project.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
