using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class AdminDashboardModel
    {
        public AdminDashboardModel()
        {
            CountEquipmentRequests = 0;
            CountServiceRequests = 0;
            countFreeAssets = 0;
            countAssignedAssets = 0;
            countFreeAssets = 0;
         
        }
        public int Id{ get; set; }
        public string Username { get; set; }
        public int CountEquipmentRequests { get; set; }
        public int CountServiceRequests { get; set; }
        public int countFreeAssets { get; set; }
        public int countAssignedAssets { get; set; }
        public int countOutOfOrderAssets { get; set; }
      
    }
    
    
}