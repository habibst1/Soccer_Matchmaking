using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;

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
            var  allstadiums  = _context.Stadiums.ToList();


            return View(allstadiums);
        }
    }
}
