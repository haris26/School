using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CategoryDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual Resources Resource { get; set; }
    }
}
