using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class History
    {
        public int ID { get; set; }
        public int AssetID { get; set; }
        public DateTime EventBegin { get; set; }
        public DateTime EventEnd { get; set; }
        public string Description { get; set; }
        public enum Status { Done=1, Processing=2}
     

    }
}
