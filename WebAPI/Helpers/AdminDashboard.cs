using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public static class AdminDashboard
    {
        public static AdminDashboardModel Create( DashboardFilterModel model)
        {
            SchoolContext context = new SchoolContext();
            AdminDashboardModel AdminDashboard = new AdminDashboardModel()
            {   
                ResultSpan = model.ResultSpan,
                NumberOfResults=model.NumberOfResults
            };

            DateTime date = DateTime.Today.AddDays(-model.ResultSpan);
            var reservations = new EventUnit(context).Get().ToList().Where(x=> x.EventStart>=date);
            int Total = reservations.Count();
            
            foreach (var reservation in reservations)
            {
                
                if (reservation.Resource.ResourceCategory.CategoryName==model.CategoryName)
                {
                    ResourceStats ResourceStatistic = new ResourceStats()
                    {
                      Id=reservation.Resource.Id,
                      ResourceName=reservation.Resource.Name
                    };
                    foreach (var ch in reservation.Resource.Characteristics)
                    {
                       ResourceStatistic.Characteristics.Add(new CharacteristicsListModel()
                        {
                            Id = ch.Id,
                            Name = ch.Name,
                            Value = ch.Value,
                        });
                    }

                    var count = reservations.Where(x => x.Resource.Name == reservation.Resource.Name).Count();
                    ResourceStatistic.Usage = Convert.ToInt32(count)/Total * 100;
                    AdminDashboard.ResourceStatistics.Add(ResourceStatistic);

                }

            }
            
            return AdminDashboard;
        }
    }
}