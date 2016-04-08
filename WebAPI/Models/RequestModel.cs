﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class RequestModel
    {
        public RequestModel()
        {
            Status = "in Process";
            RequestDate = DateTime.Now;
            

            requestType = "Equipment";

        

        }
        public int Id { get; set; }
        public string requestType { get; set; }
        public string RequestDescription { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
        public int? Asset { get; set; }
        public string AssetModel { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public int? Category { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public string AssetType { get; set; }

    }
}
