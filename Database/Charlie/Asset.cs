// PROCUREMENT SYSTEM

﻿using Database;
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
<<<<<<< HEAD:Database/Asset.cs

=======
        public string Name { get; set; }
>>>>>>> dev:Database/Charlie/Asset.cs
        public AssetType Type { get; set; }   //1-Device 2-Office
        public virtual AssetCategory AssetCategory{ get; set; } //laptop,monitor,keyboard...
        public string Model { get; set; }
        public string SerialNumber { get; set; }     //Serial/service number
        public string Description { get; set; }     // asset description [name] (I- since we added name we don't need to show this field in database)
        public string Vendor { get; set; }          // vendor - so far just description - maybe separate class in the future
        public double Price { get; set; }           // price
        public DateTime DateOfTrade { get; set; } //Date of trade in
<<<<<<< HEAD:Database/Asset.cs
 // public string EmployeeID { get; set; } we will use navigation to person instead of simple foreign key
=======
        // public string EmployeeID { get; set; } we will use navigation to person instead of simple foreign key
>>>>>>> dev:Database/Charlie/Asset.cs
        public Person User { get; set; }            // person who use particular asset 

        // public enum Status { Active=1,Coming_soon=2, Out_of_order=3 } we will put status to enumerators
        public AssetStatus Status { get; set; }
    }
}
