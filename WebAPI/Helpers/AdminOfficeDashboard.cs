using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;
using WebAPI.Models;

namespace WebApi.Helpers
{
    public static class AdminOfficeDashboard
    {
        public static AdminDashboardModel Create()
        {
            SchoolContext context = new SchoolContext();
            AdminDashboardModel dashboard = new AdminDashboardModel()
            {
                Id = AppGlobals.currentUser.Id,
                Username = AppGlobals.currentUser.FirstName
            };


            var requests = new RequestUnit(context).Get().ToList();
            foreach (var request in requests)
            {
                if (request.requestType == RequestType.Equipment && request.Status == RequestStatus.InProccess && request.AssetType == AssetType.Office)
                {
                    //dashboard.EquipmentRequests.Add(new RequestListModel()
                    //{
                    //    Id = request.Id,
                    //    RequestType = request.requestType
                    //});
                    dashboard.CountEquipmentRequests++;

                }

                else if (request.requestType == RequestType.Service && request.Status == RequestStatus.InProccess && request.AssetType == AssetType.Office)
                {
                    //dashboard.ServiceRequests.Add(new RequestListModel()
                    //{
                    //    Id = request.Id,
                    //    RequestType = request.requestType
                    //});
                    dashboard.CountServiceRequests++;
                }
            }

            //dashboard.CountEquipmentRequests = dashboard.EquipmentRequests.Count;
            //dashboard.CountServiceRequests = dashboard.ServiceRequests.Count;

            return dashboard;
        }
    }
}