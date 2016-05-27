using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class EmployeeNotification
    {
        public int Id { get; set; }
        public virtual Person Employee { get; set; }
        public bool AssessedBySupervisor { get; set; }
    }
}
