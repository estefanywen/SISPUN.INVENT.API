using Microsoft.AspNetCore.Http;
using SISPUN.Api.Aplication.Interface.Security;
 

namespace SISPUN.Api.Aplication.Utils
{
    public static class JwtReader
    {
        public static T Leerkey<T>(
            IEncryptionServerSecurity encryptionServerSecurity,
            IHttpContextAccessor httpContextAccessor,
            string key,
            T porDefecto)
        {
            return encryptionServerSecurity.Decrypt<T>(
                ReadRequest.getKeyValue<string>(httpContextAccessor, key, ""),
                porDefecto);
        }

    }
}
