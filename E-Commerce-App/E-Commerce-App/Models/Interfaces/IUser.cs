using Microsoft.AspNetCore.Mvc.ModelBinding;
using E_Commerce_App.Models.DTO;
using System.Security.Claims;

namespace E_Commerce_App.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState);

        public Task<UserDTO> Authenticate(string username, string password);

        public Task<UserDTO> GetUser(ClaimsPrincipal principal);

    }
}
