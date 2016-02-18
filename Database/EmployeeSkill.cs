<<<<<<< HEAD
﻿// SKILLS LIBRARY
namespace Database
{
//  Skill list for one person / tool
    public class EmployeeSkill
    {
        public int Id { get; set; }                     // Identity[1]
        public Level Level { get; set; }                // Level [1-5]
        public int Experience { get; set; }             // Experience [years/months]
        public virtual Tool Tool { get; set; }          // Navigation to Tool
        public virtual Person Employee { get; set; }    // Navigation to Person
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class EmployeeSkill
    {
        public int Id { get; set; }
        public int ToolId { get; set; }
        public int EmployeeId { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
>>>>>>> master
    }
}
