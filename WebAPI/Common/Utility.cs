using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public class Utility
    {
        /// <summary>
        /// Call this method to HASH a string using HMACMD5 encoding.
        /// </summary>
        /// <param name="input">The input string you want to HASH</param>
        /// <returns>The hashed value</returns>
        public async Task<string> GetHashedValue(string input)
        {
            byte[] saltBytes = new byte[] { 7, 222, 31, 20, 11, 23, 85, 6 };
            var hashBytes = new HMACMD5(saltBytes).ComputeHash(Encoding.UTF8.GetBytes(input.Trim().ToLower()));
            string saltedHashString = Convert.ToBase64String(hashBytes);
            
            return saltedHashString.ToLower();
        }
    }
}