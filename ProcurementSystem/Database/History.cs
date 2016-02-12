using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class History
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime dateBegin { get; set; }
        public DateTime dateEnd { get; set; }
        public string Description { get; set; }
        public enum Status { Done=1, Pending=2 }
    }
}
