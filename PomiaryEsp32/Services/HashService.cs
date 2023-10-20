using System.Security.Cryptography;
using System.Text;

namespace PomiaryEsp32.Services
{
    public class HashService : IHashService
    {
        public void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        public bool CompareHash(string passwordStr, byte[] passwordHash, byte[] passwordSalt)
        {
            HMACSHA512 hmac = new HMACSHA512(passwordSalt);
            var passwordHash2 = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordStr));
            return passwordHash.SequenceEqual(passwordHash2);
        }
    }
}
