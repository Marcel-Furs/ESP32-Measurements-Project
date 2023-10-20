using PomiaryEsp32.Data.Models;
using PomiaryEsp32.Data.Repositories;
using PomiaryEsp32.Exceptions;
using System.Security.Claims;

namespace PomiaryEsp32.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User, int> userRepository;
        private readonly IHashService hashService;

        public UserService(IBaseRepository<User, int> userRepository, IHashService hashService)
        {
            this.userRepository = userRepository;
            this.hashService = hashService;
        }

        public async Task CreateUser(User user, string password)
        {
            hashService.CreateHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await userRepository.Create(user);
        }

        public async Task<User> Authorize(string username, string password)
        {
            var user = await userRepository.Get(u => u.Username == username) ?? throw new InvalidCredentialsException();
            if (!hashService.CompareHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new InvalidCredentialsException();
            }
            return user;
        }

        public async Task<User> GetUserFromRequest(ClaimsPrincipal claimsPrincipal)
        {
            string id = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            return await userRepository.Get(int.Parse(id));
        }
    }
}
