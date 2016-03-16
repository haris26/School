using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcurementSystem.Models
{
    public class AssetCharModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Asset { get; set; }
        public string AssetName { get; set; }
    }
}