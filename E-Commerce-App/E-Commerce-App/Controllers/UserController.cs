using E_Commerce_App.Models;
using E_Commerce_App.Models.DTO;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

		private readonly SignInManager<UserInterface> _signInManager;

		private readonly UserManager<UserInterface> _userManager;


		public UserController(IUser user, UserManager<UserInterface> userManager, SignInManager<UserInterface> signInManager)
		{
			_user = user;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			return View();
		}
		public async Task<IActionResult> Logout()
		{


			// logout from an existing user 
			await _signInManager.SignOutAsync(); // Sign the user out

			// Redirect to the login page or return a success message
			return RedirectToAction("Index", "Home");

			// Remove the authToken cookie
			//Response.Cookies.Delete("authToken");
		}
		//[HttpGet]
		//[Authorize(Roles = "Admin")]
		//public async Task<IActionResult> Welcome()
		//{
		//    if (_signInManager.IsSignedIn(User))
		//    {
		//        var userId = _userManager.GetUserId(User);
		//        var user = await _userManager.FindByIdAsync(userId);
		//        if (user != null)
		//        {
		//            var username = user.UserName;
		//            var email = user.Email;

		//            var UserDto = new UserUpdateDTO
		//            {
		//                UserName = username,
		//                Email = email
		//            };
		//            return View(UserDto);
		//        }
		//    }
		//    return View();
		//    //var jwtToken = Request.Cookies["authToken"];
		//    //if (string.IsNullOrEmpty(jwtToken))
		//    //{
		//    //    // Handle the case where the token is null or empty.
		//    //    return BadRequest("The JWT token is missing or invalid.");
		//    //}
		//    //var handler = new JwtSecurityTokenHandler();
		//    //var jsonToken = handler.ReadToken(jwtToken);
		//    //var decodedJwt = jsonToken as JwtSecurityToken;
		//    //if (decodedJwt == null)
		//    //{
		//    //    return BadRequest("The JWT token cannot find the name it  missing.");
		//    //}
		//    //else
		//    //{
		//    //    string? username = decodedJwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Name)?.Value;
		//    //    string Role = decodedJwt.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
		//    //    if (username != null)
		//    //    {
		//    //        var userDTO = new UserDTO
		//    //        {
		//    //            UserName = username,
		//    //            Roles = new[] { Role }
		//    //        };
		//    //        return View(userDTO);
		//    //    }
		//    //    return View();
		//    //}
		//}

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
			//Data.Roles = "Admin";
			var user = await _user.Register(Data, this.ModelState);

			if (user != null)
			{
				await _user.Authenticate(Data.UserName, Data.Password, this.ModelState);
				return RedirectToAction("Index", "Home");

			}

			return View(user);
		}

		/// <summary>
		/// Authenticate a user and perform login.
		/// </summary>
		/// <param name="loginDto">Login credentials.</param>
		[HttpPost("Login")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult<UserDTO>> Login(LogInDTO loginDto)
		{

			var user = await _user.Authenticate(loginDto.UserName, loginDto.Password, this.ModelState);
			if (user != null)
			{
				return RedirectToAction("Index", "Home");
			}
			return View(user);
			//}
			//return View();
			//string jwtToken = user.Token;
			//var cookieOptions = new CookieOptions
			//{
			//    HttpOnly = true,
			//    Secure = true,
			//    SameSite = SameSiteMode.Strict,
			//    Expires = DateTime.UtcNow.AddMinutes(30)
			//};

			//// Set the JWT token in the cookie
			//Response.Cookies.Append("authToken", jwtToken, cookieOptions);
		}

		/// <summary>
		/// Get the profile information of the currently authenticated user.
		/// </summary>
		//[HttpGet("Profile")]
		//public async Task<ActionResult<UserDTO>> Profile()
		//{
		//    var profile = await _user.GetUser(this.User);

		//    return Ok(profile);
		//}

	}
}
