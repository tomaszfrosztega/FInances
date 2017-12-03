using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.Extensions;
using System.Security.Cryptography;

namespace Finances.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DeriveByterIterationCount = 10000;

        private static readonly int SaltSize = 40;


        public string GetSalt(string value)
        {
            if (value.Empty())
            {
                throw new ArgumentException("Can not generate salt from empty value.", nameof(value));
            }

            var saltBytes = new byte[SaltSize];
            var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (value.Empty())
            {
                throw new ArgumentException("Can not generate hash from empty value.", nameof(value));
            }

            if (salt.Empty())
            {
                throw new ArgumentException("Can not use empty salt from hashing value.", nameof(value));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveByterIterationCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
