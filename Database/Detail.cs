using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Detail
    {
        public int Id { get; set; }
        public int TimeCategoryId { get; set; }
        public int CalendarId { get; set; }
        public int TeamId { get; set; }
        public double WorkTime { get; set; }
        public double BillTime { get; set; }
        public string Description { get; set; }
    }
}
