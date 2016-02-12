using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Calendar
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        double WorkTime { get; set; }
        double PtoTime { get; set; }
        public Status Status { get; set; }
    }
}


