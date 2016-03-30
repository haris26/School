using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using Database;

namespace WebAPI.Helpers
{
    public static class AppGlobals
    {
        public static Person currentUser
        {
            get
            {
                if (!Thread.CurrentPrincipal.Identity.IsAuthenticated) return null;
                string username = Thread.CurrentPrincipal.Identity.Name;
                if (username == null) username = HttpContext.Current.User.Identity.Name;
                var person = (new Repository<Person>(new SchoolContext())).Get().Where(x => x.FirstName == username).FirstOrDefault();
                if (person == null) person = (new Repository<Person>(new SchoolContext())).Get().Where(x => x.FirstName + x.LastName.Substring(0, 1) == username).FirstOrDefault();
                return person;
            }
        }

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
