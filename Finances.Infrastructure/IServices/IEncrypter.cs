using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Infrastructure.IServices
{
    public interface IEncrypter
    {
        string GetSalt(string value);

        string GetHash(string value, string salt);
    }
}
