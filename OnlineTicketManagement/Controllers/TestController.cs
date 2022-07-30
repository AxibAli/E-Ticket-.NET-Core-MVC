using Microsoft.AspNetCore.Mvc;

namespace OnlineTicketManagement.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
