using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkforceRoster.Models
{
    public class TeamModel
    {
        public TeamModel()
        {
            Members = new List<string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public IList<string> Members { get; set; }
    }
}