using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DashboardFilterModel
    {
        public int ResultSpan { get; set; }
        public int NumberOfResults { get; set; }
        public string CategoryName { get; set; }
    }
}