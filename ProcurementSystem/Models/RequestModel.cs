using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcurementSystem.Models
{
    public class RequestModel
    {
        public int Id { get; set; }
        public RequestType requestType { get; set; }
        public string RequestDescription { get; set; }
        public string RequestMessage { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }  
        public int Asset { get; set; }
        public string AssetModel { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }

    }
}