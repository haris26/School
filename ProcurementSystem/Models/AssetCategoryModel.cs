using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcurementSystem.Models
{
    public class AssetCategoryModel
    {
        public AssetCategoryModel()
        {
            Assets = new List<string>();
            AssetCharacteristicNames = new List<string>();
        }        
        public int Id { get; set; }                       //Identity[1]
        public string CategoryName { get; set; }          //Name of the category
        public string Type { get; set; }
        public int Category { get; set; }
        public virtual IList<string> Assets { get; set; }
        public virtual IList<string> AssetCharacteristicNames { get; set; }
    }
}