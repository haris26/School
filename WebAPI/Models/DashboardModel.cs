using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ListModel
    {
        public string Category { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string SerialNumber { get; set; }
        public string Vendor { get; set; }

    }

    public class ListRequestsModel {
        public string Type { get; set; }
        public string Category { get; set; }
        public string Description  { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }


    public class DashboardModel
    {
        public DashboardModel()
        {
           
            Assets = new List<ListModel>();
            Requests = new List<ListRequestsModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        
        public IList<ListModel> Assets { get; set; }
        public IList<ListRequestsModel> Requests { get; set; }
    }
}