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
        public int Id { get; set; }
        public virtual ResourceCategory ResourceCategory { get; set; }      //Navigation to the resource category
        public string Name { get; set; }                                    // Name of characteristics
    }
}
