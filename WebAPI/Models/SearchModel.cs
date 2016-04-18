using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class SearchModel
    {
        public SearchModel()
        {
            this.ToDate = System.DateTime.Today;
        }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CategoryName { get; set; }
        public string ResourceName { get; set; }
        public string OsType { get; set; }
    }
}