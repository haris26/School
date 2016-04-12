using System;
using System.Collections.Generic;
using System.Linq;
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

            var sign = Convert.ToBase64String(hash);

            return sign;
        }

        public static string GenerateToken(ApiUser user)
        {
            var provider = new System.Security.Cryptography.HMACSHA256(Convert.FromBase64String(user.AppId));
            var rawTokenInfo = string.Concat(user.AppId + DateTime.UtcNow.ToString("d"));
            var rawTokenByte = Encoding.UTF8.GetBytes(rawTokenInfo);
            var token = provider.ComputeHash(rawTokenByte);
            return Convert.ToBase64String(token);
        }
        public static List<string> GetRoles(Person currentUser)
        {
            return currentUser.Roles.Where(x => x.Role.System).OrderBy(x => x.Role.Name).Select(x => x.Role.Name).Distinct().ToList();
        }
    }
}
