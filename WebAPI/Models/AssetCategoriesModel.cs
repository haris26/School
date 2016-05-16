using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{

    public class AssetCharacteristicNamesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public int Category { get; set; }

    }

    public class AssetCategoriesModel
    {
        public AssetCategoriesModel()
        {
            Assets = new List<AssetsModel>();
            AssetCharacteristicNames = new List<AssetCharacteristicNamesModel>();

        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Type { get; set; }
        public int Category { get; set; }
        public IList<AssetsModel> Assets { get; set; }
        public IList<AssetCharacteristicNamesModel> AssetCharacteristicNames { get; set; }
    }
}