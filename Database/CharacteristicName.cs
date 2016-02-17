using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{   
    // Name of characteristics for specific category 
    public class CharacteristicName
    {
        public virtual ResourceCategory ResourceCategory { get; set; }      //Navigation to the resource category
        public virtual Characteristic Name { get; set; }                    // Navigation to the characteristics of resource category
    }
}
