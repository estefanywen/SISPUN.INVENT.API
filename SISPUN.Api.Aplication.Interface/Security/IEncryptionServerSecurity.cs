using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.Aplication.Interface.Security
{
    public interface IEncryptionServerSecurity
    {
        string Encrypt(string input);
        T Decrypt<T>(string input, T porDefecto);
    }
}
