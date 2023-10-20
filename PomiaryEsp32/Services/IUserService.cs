using PomiaryEsp32.Data.Models;
using System.Security.Claims;

namespace PomiaryEsp32.Services
{
    public interface IUserService
    {
        Task<User> Authorize(string username, string password);
        Task CreateUser(User user, string password);
        Task<User> GetUserFromRequest(ClaimsPrincipal claimsPrincipal);
    }
}