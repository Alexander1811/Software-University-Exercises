namespace FootballManager.Services
{
    using FootballManager.Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashingService : IHashingService
    {
        public string HashString(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using SHA256 sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
        }
    }
}
