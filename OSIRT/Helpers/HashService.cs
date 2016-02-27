using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OSIRT.Helpers
{
    public class HashService
    {
        public HashService(HashAlgorithm algorithm)
        {
            HashAlgorithm = algorithm;
            Encoder = Encoding.UTF8;
        }

        public HashAlgorithm HashAlgorithm
        {
            get;
            set;
        }

        public Encoding Encoder { get; set; }

        public string ComputeHash(string input)
        {
            byte[] bytes = Encoder.GetBytes(input);
            byte[] hash = ComputeHash(bytes);
            return ToHex(hash);

        }

        public byte[] ComputeHash(byte[] buffer)
        {
            return HashAlgorithm.ComputeHash(buffer);
        }

        public byte[] ComputeHash(Stream inputStream)
        {
            return HashAlgorithm.ComputeHash(inputStream);
        }

        public string ToHex(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToUpper();
        }
    }
}
