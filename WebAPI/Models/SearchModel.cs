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
            this.FromDate = System.DateTime.Today;
        }
        public string ResourceName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string CategoryName { get; set; }

    }
}