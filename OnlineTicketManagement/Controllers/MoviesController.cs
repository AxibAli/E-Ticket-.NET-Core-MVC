using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineTicketManagement.Data;
using OnlineTicketManagement.Data.Servies;
using OnlineTicketManagement.Models;
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
        public IActionResult Create()
        {
            var movieDataDropdown = services.GetNewMovieDropdown();
            ViewBag.Actors = new SelectList(movieDataDropdown.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDataDropdown.Producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDataDropdown.Cinemas, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewMoviesVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDataDropdown = services.GetNewMovieDropdown();
                ViewBag.Actors = new SelectList(movieDataDropdown.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDataDropdown.Producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDataDropdown.Cinemas, "Id", "Name");
                return View(movie);
            }
            services.AddNewMovie(movie);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var check = services.GetMovieById(id);
            if (check == null)
                return View("NotFound", "Actor");

            var response = new NewMoviesVM()
            {
                Id = check.Id,
                Name = check.Name,
                Description = check.Description,
                StartDate = check.StartDate,
                EndDate = check.EndDate,
                Price = check.Price,
                MovieCategory = check.MovieCategory,
                CinemaId = check.CinemaId,
                ImageUrl = check.ImageUrl,
                ProducerId = check.ProducerId,
                ActorIds = check.Actor_Movies.Select(n => n.ActorId).ToList(),
            };
            var movieDataDropdown = services.GetNewMovieDropdown();
            ViewBag.Actors = new SelectList(movieDataDropdown.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDataDropdown.Producers, "Id", "FullName");
            ViewBag.Cinemas = new SelectList(movieDataDropdown.Cinemas, "Id", "Name");
            return View(response);
        }
        [HttpPost]
        public IActionResult Edit(int id, NewMoviesVM movie)
        {
            if (id != movie.Id)
                return View("NotFound", "Actor");
            if(!ModelState.IsValid)
            {
                var movieDataDropdown = services.GetNewMovieDropdown();
                ViewBag.Actors = new SelectList(movieDataDropdown.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDataDropdown.Producers, "Id", "FullName");
                ViewBag.Cinemas = new SelectList(movieDataDropdown.Cinemas, "Id", "Name");
                return View(movie);
            }
            services.UpdateMovie(movie);
            return RedirectToAction("Index");
        }
    }
    }

