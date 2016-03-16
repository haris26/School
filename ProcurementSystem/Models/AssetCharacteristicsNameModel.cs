using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ProcurementSystem.Models
{
    public class AssetCharacteristicsNameModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int AssetCategory { get; set; }
        public string AssetCategoryName { get; set; }
    }
}