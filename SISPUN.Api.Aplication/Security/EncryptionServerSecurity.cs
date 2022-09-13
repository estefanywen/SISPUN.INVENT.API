using Microsoft.AspNetCore.DataProtection;
using SISPUN.Api.Aplication.Interface.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.Aplication.Security
{
    public class EncryptionServerSecurity : IEncryptionServerSecurity
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "99401632e98ba0f3dbcfdafc5c5d3320f242394d";

        public EncryptionServerSecurity(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Encrypt(string input)
        {
            if (input == null)
            {
                return input;
            }
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }

        public T Decrypt<T>(string input, T porDefecto)
        {
            if (input == null)
            {
                return porDefecto;
            }
            else
            {
                var protector = _dataProtectionProvider.CreateProtector(Key);
                return (T)Convert.ChangeType(protector.Unprotect(input), typeof(T));
            }
        }
    }
}
