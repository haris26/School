using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeTracking.Models
{
    public class RoleModel
    {
        public RoleModel()
        {
            Members = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Team { get; set; }              // Is it team role? [like developer, qa, team lead...]
        public bool System { get; set; }
        public IList<string> Members { get; set; }
    }
}