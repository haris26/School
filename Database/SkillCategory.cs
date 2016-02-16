using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class SkillCategory
    {
        public SkillCategory()
        {
            Tools = new Collection<Tool>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Tool> Tools { get; set; }
    }
}
