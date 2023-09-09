using E_Commerce_App.Models.DTO;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce_App.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Logout()
        {
            // Remove the authToken cookie
            Response.Cookies.Delete("authToken");

            // Redirect to the login page or return a success message
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        [Authorize]
        public IActionResult Welcome()
        {
            var jwtToken = Request.Cookies["authToken"];
            if (string.IsNullOrEmpty(jwtToken))
            {
                // Handle the case where the token is null or empty.
                return BadRequest("The JWT token is missing or invalid.");
            }
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtToken);
            var decodedJwt = jsonToken as JwtSecurityToken;
            if (decodedJwt == null)
            {
                return BadRequest("The JWT token cannot find the name it  missing.");
            }
            else
            {
                string? username = decodedJwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
                string Role = decodedJwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
                if (username != null)
                {
                    var userDTO = new UserDTO
                    {
                        UserName = username,
                        Roles = new[] { Role }
                    };
                    return View(userDTO);
                }
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="Data">Registration data for the new user.</param>
        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO Data)
        {
            Data.Roles = "Admin";
            var user =  await _user.Register(Data, this.ModelState);

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Authenticate a user and perform login.
        /// </summary>
        /// <param name="loginDto">Login credentials.</param>
        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
        {
            var user = await _user.Authenticate(loginDto.UserName, loginDto.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            string jwtToken = user.Token;

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddMinutes(30)
            };

            // Set the JWT token in the cookie
            Response.Cookies.Append("authToken", jwtToken, cookieOptions);

            // Redirect to a protected page or return a success message
            return RedirectToAction("welcome","User");
        }

        /// <summary>
        /// Get the profile information of the currently authenticated user.
        /// </summary>
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDTO>> Profile()
        {
            var profile = await _user.GetUser(this.User);

            return Ok(profile);
        }

    }
}
