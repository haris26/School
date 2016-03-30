using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class QueriedSkill
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
    }

    public class SearchModel
    {
        public SearchModel()
        {
            QueriedSkills = new List<QueriedSkill>();
            QueriedEducations = new List<int>();
        }

        public IList<QueriedSkill> QueriedSkills { get; set; }
        public IList<int> QueriedEducations { get; set; }
    }
}