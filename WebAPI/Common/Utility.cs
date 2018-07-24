using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common
{
    public class Utility
    {
        /// <summary>
        /// Call this method to HASH a string using MD5 encoding.
        /// </summary>
        /// <param name="input">The input string you want to HASH</param>
        /// <returns>The hashed value</returns>
        public async Task<string> GetHashedValue(string input)
        {
            var tmpSource = Encoding.ASCII.GetBytes(input.Trim().ToLower());
            var hashBytes = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString().ToLower();
        }
    }
}