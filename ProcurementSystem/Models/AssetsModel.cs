using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ProcurementSystem.Models
{
  
        public class AssetsModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int User { get; set; }
            public string UserName { get; set; }
            public string Model { get; set; }
            public Database.AssetType Type { get; set; }
            // public IList<string> Assets { get; set; }
            public string SerialNumber { get; set; }
            public string Vendor { get; set; }
            public double Price { get; set; }
            public DateTime DateOfTrade { get; set; }
            public AssetStatus Status { get; set; }
            public int Category { get; set; }
            public string CategoryName { get; set; }

        
    }
}