using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Database;
using System.Text;

namespace WebAPI.Helpers
{
    public static class AppGlobals
    {
        public static Person currentUser;

        public static string Signature(string Secret, string AppId)
        {

            byte[] secret = Convert.FromBase64String(Secret);
            byte[] appId = Convert.FromBase64String(AppId);
            var provider = new System.Security.Cryptography.HMACSHA256(secret);
            string key = System.Text.Encoding.Default.GetString(appId);
            var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            return Convert.ToBase64String(hash);
        }

        public static string GenerateToken(ApiUser user)
        {
            var provider = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(user.AppId));
            var rawTokenInfo = string.Concat(user.AppId + DateTime.UtcNow.ToString("d"));
            var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
            var token = provider.ComputeHash(rawTokenByte);
            return Convert.ToBase64String(token);
        }
    }
}
