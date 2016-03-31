using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    //public class RequestListModel
    //{
    //    public int Id { get; set; }
    //    public RequestType RequestType { get; set; }
    //}

    public class AdminDashboardModel
    {
        public AdminDashboardModel()
        {
            CountEquipmentRequests = 0;
          //  CountApprovedRequests = 0;
            CountServiceRequests = 0;
           // CountOutOfStorage = 0;

            //EquipmentRequests = new List<RequestListModel>();
            //ServiceRequests = new List<RequestListModel>();
            //ApprovedRequests = new List<RequestListModel>();
        }
        public int Id{ get; set; }
        public string Username { get; set; }
        public int CountEquipmentRequests { get; set; }
        public int CountServiceRequests { get; set; }
        //  public int CountApprovedRequests { get; set; }
      //  public int CountOutOfStorage { get; set; }


        //public IList<RequestListModel> EquipmentRequests{ get; set; }
        //public IList<RequestListModel> ServiceRequests { get; set; }
        //public IList<RequestListModel> ApprovedRequests { get; set; }
    }
    
    
}