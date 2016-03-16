using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MemberModel
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
    public class TeamModel
    {
        public TeamModel()
        {
            Members = new List<MemberModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IList<MemberModel> Members { get; set; }
    }
}