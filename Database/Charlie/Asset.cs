using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    //  Basic assets data
    public class Asset
    {

        public int Id { get; set; }
        public string Name { get; set; }
        //  public AssetType Type { get; set; }   //1-Device 2-Office
        public virtual AssetCategory AssetCategory { get; set; } //laptop,monitor,keyboard...
        public string Model { get; set; }
        public string SerialNumber { get; set; }     //Serial/service number
        public string Vendor { get; set; }          // vendor - so far just description - maybe separate class in the future
        public double Price { get; set; }           // price
        public DateTime DateOfTrade { get; set; } //Date of trade in
        public virtual Person User { get; set; }            // person who use particular asset 
        public AssetStatus Status { get; set; }
       


    }
    
}
