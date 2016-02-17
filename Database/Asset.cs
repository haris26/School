using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Asset
    {

        public int AssetId { get; set; }
        public string Description { get; set; }
        public AssetType Type { get; set; }
        virtual public CategoryPs Cat { get; set; }
        Dictionary<string, string> Characteristics = new Dictionary<string, string>();
        public string Vendor { get; set; }
        public double Price { get; set; }
        virtual public string EmployeeID { get; set; }
        public AssetStatus Status { get; set; }

}
    
}
