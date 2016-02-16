using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EmployeeSkill
    {
        public int Id { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        public virtual Tool Tool { get; set; }
        public virtual Person Employee { get; set; }
    }
}
