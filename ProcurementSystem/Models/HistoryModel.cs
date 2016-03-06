using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace ProcurementSystem.Models
{
    public class HistoryModel
    {
        public int Id { get; set; }
        public DateTime EventBegin { get; set; }
        public DateTime? EventEnd { get; set; }
        public string Description { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public int Team { get; set; }
        public int Asset { get; set; }
        public string AssetModel { get; set; }
        public HistoryStatus Status { get; set; }
    }
}