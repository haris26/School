<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

// SKILLS LIBRARY
namespace Database
{
//  Categories: languages, collaboration tools, project management...
    public class SkillCategory
    {
        public SkillCategory()
        {
            Tools = new Collection<Tool>();
        }

        public int Id { get; set; }                                 // Identity[1]
        public string Name { get; set; }                            // Category name

        public virtual ICollection<Tool> Tools { get; set; }        // List of tools
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class SkillCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
>>>>>>> master
    }
}
