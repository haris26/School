using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ListReqModel
    {
        public string Type { get; set; }
        public string User { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

    }

    public class ListAssetModel {

        public string Category { get; set; }
        public string User { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string SerialNumber { get; set; }
        public string Vendor { get; set; }

    }


    public class AdminDashboardModel
    {
        public AdminDashboardModel()
        {
            CountEquipmentRequests = 0;
            CountServiceRequests = 0;
            countFreeAssets = 0;
            countAssignedAssets = 0;
            countFreeAssets = 0;
            countAllAssets = 0;
            Requests = new List<ListReqModel>();
            ServiceRequests = new List<ListReqModel>();
            AssignedAssets = new List<ListAssetModel>();
            FreeAssets = new List<ListAssetModel>();
            OutOfOrderAssets = new List<ListAssetModel>();
            AllAssets = new List<ListAssetModel>();

        }

        public int Id{ get; set; }
        public string Username { get; set; }
        public int CountEquipmentRequests { get; set; }
        public int CountServiceRequests { get; set; }
        public int countFreeAssets { get; set; }
        public int countAssignedAssets { get; set; }
        public int countOutOfOrderAssets { get; set; }
        public int countAllAssets { get; set; }
        public IList<ListReqModel> Requests { get; set; }
        public IList <ListReqModel>ServiceRequests { get; set; }
        public IList<ListAssetModel> AssignedAssets { get; set; }
        public IList<ListAssetModel> FreeAssets { get; set; }
        public IList<ListAssetModel> OutOfOrderAssets { get; set; }
        public IList<ListAssetModel> AllAssets { get; set; }

    }
    
    
}