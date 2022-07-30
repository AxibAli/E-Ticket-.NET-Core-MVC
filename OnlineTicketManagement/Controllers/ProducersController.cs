using Microsoft.AspNetCore.Mvc;
using OnlineTicketManagement.Data;
using OnlineTicketManagement.Data.Servies;
using OnlineTicketManagement.Models;
using System.Linq;

namespace OnlineTicketManagement.Controllers
{
    public class ProducersController : Controller
    {
        private readonly IProducerServices services;
        public ProducersController(IProducerServices _services)
        {
            services = _services;
        }

        public IActionResult Index()
        {
            var data = services.GetAll();
            return View(data);
        }
        public IActionResult Details(int id)
        {
            var data= services.GetById(id);
            return View(data);
        }
        public IActionResult Edit(int id)
        {
            var data = services.GetById(id);
            if(data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,ProfilePictureUrl,FullName,Bio")] Producer producer)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            services.Update(id, producer);
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,ProfilePictureUrl,FullName,Bio")] Producer producer)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            services.Add(producer);
            return RedirectToAction("Index");
            
        }
        public IActionResult Delete(int id)
        {
            var data = services.GetById(id);
            if (data == null)
                return View("NotFound", "Actor");
            return View(data);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePostt(int id)
        {
            services.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
