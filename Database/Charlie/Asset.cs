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
        public Asset()
        {
            assetCharacteristics = new List<AssetChar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual AssetCategory AssetCategory { get; set; } //laptop,monitor,keyboard...
        public string Model { get; set; }
        public string SerialNumber { get; set; }     //Serial/service number
        public string Vendor { get; set; }          // vendor - so far just description - maybe separate class in the future
        public double Price { get; set; }           // price
        public DateTime DateOfTrade { get; set; } //Date of trade in
        public DateTime? DateOfAssign { get; set; }
        public virtual Person User { get; set; }            // person who use particular asset 
        public AssetStatus Status { get; set; } // Assigned = 1,Free = 2, OutOfStock = 3
        public virtual List<AssetChar> assetCharacteristics { get; set; }



    }
    
}
