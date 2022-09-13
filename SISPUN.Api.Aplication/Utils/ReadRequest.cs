using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;


namespace SISPUN.Api.Aplication.Utils
{
    public static class ReadRequest
    {
        public static JwtSecurityToken getToken(IHttpContextAccessor httpContextAccessor)
        {
            JwtSecurityToken token = null;
            try
            {
                var handler = new JwtSecurityTokenHandler();
                string authHeader = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
                authHeader = authHeader.Replace("Bearer ", "");
                token = handler.ReadToken(authHeader) as JwtSecurityToken;
            }
            catch (Exception) { }
            return token;
        }

        public static T getKeyValue<T>(IHttpContextAccessor httpContextAccessor, string keyToken, T porDefecto)
        {
            T value;
            try
            {
                JwtSecurityToken token = getToken(httpContextAccessor);
                return (T)Convert.ChangeType(token.Claims.First(claim => claim.Type == keyToken).Value, typeof(T));
            }
            catch (Exception)
            {
                value = porDefecto;
            }
            return value;
        }
    }
}
