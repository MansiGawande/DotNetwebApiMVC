using FirstDotNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FirstDotNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UsersDbContext _context;

        public HomeController(ILogger<HomeController> logger , UsersDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()    
        {
            return View();
        }
        public IActionResult CreateEditUser(int? id)
        {

        }
        public IActionResult CreateEditUserForm(User model)
        {
            _context.Users.Add(model);

            _context.SaveChanges();

            return RedirectToAction("Users"); // move to UserCs.html
        }
        public IActionResult UserAddEdit()
        {
            return View();
        }
        public IActionResult Users()
        {
            var allusers = _context.Users.ToList();
            return View(allusers);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
