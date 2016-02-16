using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Asset
    {
        [Key]
        public int AssetId { get; set; }
        public string Description { get; set; }
        Dictionary<string, string> Characteristics = new Dictionary<string, string>();
        public string Vendor { get; set; }
        public double Price { get; set; }
        virtual public string  EmployeeID { get; set; }
        public enum Status { Active=1,Coming_soon=2, Out_of_order=3 }
    }
}
