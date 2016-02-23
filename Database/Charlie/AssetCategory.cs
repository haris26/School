using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
   public class AssetCategory
    {
       
        public int Id { get; set; }                       //Identity[1]
        public string CategoryName { get; set; }          //Name of the category

        public virtual ICollection<AssetCharacteristicNames> AssetCharacteristicNames { get; set; }
    }
}
