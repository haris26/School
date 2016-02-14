using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class Assets
    {
        public int AssetID { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public double Price { get; set; }
        public string EmployeeID { get; set; }
        public enum Status { Active=1,Coming_soon=2, Out_of_order=3 }
    }
}
