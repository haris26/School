using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class TokenModel
    {
        public TokenModel()
        {
            Roles = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}