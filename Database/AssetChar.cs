using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
   public class AssetChar
    {

        public int Id { get; set; }                                         // Identity[1]
        public string Name { get; set; }                                    // Name of the charasteristic
        public string Value { get; set; }                                   // Value of the characteristic
        public virtual Asset Asset { get; set; }
    }
}
