using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Models.DTO;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace E_Commerce_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly SignInManager<UserInterface> _signInManager;

        private readonly UserManager<UserInterface> _userManager;

        public HomeController(ILogger<HomeController> logger, UserManager<UserInterface> userManager, SignInManager<UserInterface> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userid = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userid);
                if (user != null)
                {
                    var result = new UserDTO
                    {
                        UserName = user.UserName
                    };
                    return View(result);
                }
            }
            return View();

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
