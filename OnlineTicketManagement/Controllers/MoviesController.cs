using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Data;
using OnlineTicketManagement.Data.Servies;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTicketManagement.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieServices services;
        public MoviesController(IMovieServices _services)
        {
            services = _services;
        }

        public IActionResult Index()
        {
            var data = services.GetAll(n=>n.Cinema);
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data = services.GetMovieById(id);
            if (data == null)
                return View("NotFound", "Actor");
            return View(data);
           
        }
    }
}
