namespace PomiaryEsp32.Services
{
    public interface IHashService
    {
        bool CompareHash(string passwordStr, byte[] passwordHash, byte[] passwordSalt);
        void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    }
}