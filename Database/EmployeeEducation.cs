using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EmployeeEducation
    {
        public int Id { get; set; }

        public virtual Person Employee { get; set; }
        public virtual Education Education { get; set; }
    }
}
