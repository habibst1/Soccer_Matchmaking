using Dotnet_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Details(int id)
        {
            var stadium = _context.Stadiums.Include(s => s.Times).FirstOrDefault(st => st.Id == id);


            return View(stadium);
        }
    }
}
