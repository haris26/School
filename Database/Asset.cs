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
        // public int AssetId { get; set; } instead of classId in all our projects we will use just Id (convention)
        public int Id { get; set; }

        public AssetType Type { get; set; }
        public string Name { get; set; }
        public int SerialNumber { get; set; }
        public string Description { get; set; }     // asset description [name]
        public string Vendor { get; set; }          // vendor - so far just description - maybe separate class in the future
        public double Price { get; set; }           // price



        public Dictionary<string, string> Characteristics = new Dictionary<string, string>();
        public void Set(string key, string value)
        {
            if (Characteristics.ContainsKey(key))
            {
                Characteristics[key] = value;
            }
            else
            {
                Characteristics.Add(key, value);
            }
        }

        public string Get(string key)
        {
            string result = null;

            if (Characteristics.ContainsKey(key))
            {
                result = Characteristics[key];
            }

            return result;
        }

        // public string EmployeeID { get; set; } we will use navigation to person instead of simple foreign key
        public Person User { get; set; }            // person who use particular asset 

        // public enum Status { Active=1,Coming_soon=2, Out_of_order=3 } we will put status to enumerators
        public AssetStatus Status { get; set; }
    }
}
