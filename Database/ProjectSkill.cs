using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ProjectSkill
    {
        public int Id { get; set; }
        public int Level { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual Team Team { get; set; }
    }
}
