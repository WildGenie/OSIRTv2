using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class HashServiceFactory
    {
        private static Dictionary<string, HashService> hashAlgorithms = new Dictionary<string, HashService>()
        {
            { "md5", new HashService(new MD5CryptoServiceProvider()) },
            { "sha1", new HashService(new SHA1CryptoServiceProvider()) },
            { "sha256", new HashService(new SHA256CryptoServiceProvider()) },
            { "sha384", new HashService(new SHA384CryptoServiceProvider()) },
            { "sha512", new HashService(new SHA512CryptoServiceProvider()) },

        };

        private HashServiceFactory(){ }

        /// <summary>
        /// Creates an instance of a HashService
        /// </summary>
        /// <param name="algorithmRequired">The has algorithm required</param>
        /// <returns>A HashService to hash</returns>
        public static HashService Create(string algorithmRequired)
        {
            HashService hashService;

            if (!hashAlgorithms.TryGetValue(algorithmRequired.ToLowerInvariant(), out hashService))
            {
                throw new KeyNotFoundException("Hash is not found");
            }

            return hashService;
        }

        /// <summary>
        /// Gets the KeySet of the available hash algorithms
        /// </summary>
        /// <returns>A list of available hashing alogorithms</returns>
        public static List<string> AvailableHashAlgorithms()
        {
            return new List<string>(hashAlgorithms.Keys);
        }
    }
}
