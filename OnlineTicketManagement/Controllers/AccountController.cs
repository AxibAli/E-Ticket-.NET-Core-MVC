using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTicketManagement.Data;
using OnlineTicketManagement.Data.ViewModel;
using OnlineTicketManagement.Models;
using System.Threading.Tasks;

namespace OnlineTicketManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly TicketDbContext db;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, TicketDbContext _db)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            var response = new LoginVM();
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);
            var user = await userManager.FindByEmailAsync(loginVM.EmailAddress);
            if(user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, loginVM.Password);
                if(passwordCheck)
                {
                    var result = await signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");
                    }
                }
                TempData["Error"] = "Wrong Credentials Please Try Again";
                return View(loginVM);

            }
            TempData["Error"] = "Wrong Credentials Please Try Again";
            return View(loginVM);


        }
    }
}
