namespace PomiaryEsp32.Services
{
    public interface ITokenService
    {
        string CreateToken(string userId, string username);
    }
}