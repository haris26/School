using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ListModel
    {
        public string CategoryName { get; set; }
        public int Category { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string SerialNumber { get; set; }
        public string Vendor { get; set; }
        public int User { get; set; }
        public int Asset { get; set; }


    }

    public class ListRequestsModel {
        public string Type { get; set; }
        public int Category { get; set; }
        public string CategoryName { get; set; }
        public string Description  { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string ServiceType { get; set; }

    }


    public class DashboardModel
    {
        public DashboardModel()
        {
           
            Assets = new List<ListModel>();
            NewRequests = new List<ListRequestsModel>();
            ServiceRequests = new List<ListRequestsModel>();
            countStatusChange = 0;
           

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int countStatusChange { get; set; }
      
        public IList<ListModel> Assets { get; set; }
        public IList<ListRequestsModel> NewRequests { get; set; }
       
        public IList<ListRequestsModel> ServiceRequests { get; set; }
    }
}