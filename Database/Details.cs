using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Details
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CalendarId { get; set; }
        public int ProjectId { get; set; }
        public double WorkTime { get; set; }
        public double BillTime { get; set; }
    }
}
