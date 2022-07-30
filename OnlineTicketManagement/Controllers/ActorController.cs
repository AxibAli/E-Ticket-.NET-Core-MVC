using Microsoft.AspNetCore.Mvc;
using OnlineTicketManagement.Data;
using OnlineTicketManagement.Data.Servies;
using OnlineTicketManagement.Models;
using System.Linq;

namespace OnlineTicketManagement.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorServices services;

        public ActorController(IActorServices _services)
        {
            services = _services;
        }

        public IActionResult Index()
        {
            var Data = services.GetAll();
            return View(Data);
        }
        public IActionResult Create ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View(actor);
            }
            services.Add(actor);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var data = services.GetById(id);
            if (data == null) return View("Empty");
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var data = services.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            services.Update(id, actor);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = services.GetById(id);
            if (result == null)
                return View("NotFound");
            return View(result);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteMethod(int id)
        {
            var result = services.GetById(id);
            if (result == null)
                return View("NotFound");
            services.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
