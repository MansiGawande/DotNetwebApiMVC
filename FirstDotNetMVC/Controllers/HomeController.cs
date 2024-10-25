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

        public IActionResult DeleteUser(int? id)
        {
            var userInDb = _context.Users.SingleOrDefault(user => user.Id == id);
            _context.Users.Remove(userInDb);
            _context.SaveChanges();
                return RedirectToAction("Users"); // move to UserCs.html
        }
        public IActionResult CreateEditUser(int id){
            if(id != null){
            var userInDb = _context.Users.SingleOrDefault(user => user.Id == id);
                return View(userInDb);
                    
            }

            return View();
        }
    
        public IActionResult CreateEditUserForm(User model)
        {
            if(model.Id == 0)
            {
            _context.Users.Add(model);

            } else
            {
                _context.Users.Update(model);
            }

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
