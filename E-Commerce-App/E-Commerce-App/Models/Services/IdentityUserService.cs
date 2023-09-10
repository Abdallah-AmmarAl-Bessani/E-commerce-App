using E_Commerce_App.Models.DTO;
using E_Commerce_App.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce_App.Models.Services
{
    public class IdentityUserService : IUser
    {
        private readonly UserManager<UserInterface> _userManager;
        //private readonly JWTTokenService _jwtTokenService;
        private readonly SignInManager<UserInterface> _signInManager;
        private RoleManager<IdentityRole> _roleManager;



        public IdentityUserService(UserManager<UserInterface> userManager, SignInManager<UserInterface> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            //_jwtTokenService = jwtTokenService;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<UserDTO> Authenticate(string username, string password, ModelStateDictionary modelState)
        {
            
                var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);

                return new UserDTO
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    //Token = await _jwtTokenService.GetToken(user, System.TimeSpan.FromMinutes(100)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }
            modelState.AddModelError(string.Empty, "Username or password wrong");
            return null;

        }

        public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);

            return new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                //Token = await _jwtTokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
                Roles = await _userManager.GetRolesAsync(user)
            };
        }



        public async Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState)
        {
            if (registerUser.UserName != null && registerUser.Password != null)
            {
                var user = new UserInterface()
                {
                    UserName = registerUser.UserName,
                    Email = registerUser.Email,
                    
                };

                var result = await _userManager.CreateAsync(user, registerUser.Password);
                //registerUser.Roles = "Admin";

                if (result.Succeeded)
                {
                    var roleExists = await _roleManager.RoleExistsAsync(registerUser.Roles);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerUser.Roles));
                    }

                    await _userManager.AddToRoleAsync(user, registerUser.Roles);

                    return new UserDTO
                    {
                        Id = user.Id,
                        UserName = user.UserName,
                        Roles = await _userManager.GetRolesAsync(user)
                    };
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        var errorKey =
                          error.Code.Contains("Password") ? nameof(registerUser.Password) :
                          error.Code.Contains("Email") ? nameof(registerUser.Email) :
                          error.Code.Contains("UserName") ? nameof(registerUser.UserName) :
                          "";

                        //modelState.AddModelError(errorKey, error.Description);
                    }
                }
               
            }
            modelState.AddModelError(string.Empty, "You have to fill all fields!");
            return null;
        }

    }
}
