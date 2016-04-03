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
            IList<ResourceStats> statistics = new List<ResourceStats>();
            DateTime date = DateTime.Today.AddDays(-model.ResultSpan);
            var reservations = new EventUnit(context).Get().ToList().Where(x => x.EventStart >= date).GroupBy(x => x.Resource.Name).Select(x => x.First()).ToList();
            
           
            foreach (var reservation in reservations)
            {
               
                if (reservation.Resource.ResourceCategory.CategoryName==model.CategoryName)
                {
                    double totalTime = 0.00;
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
                    var timeReservations = new EventUnit(context).Get().Where(x => x.Resource.ResourceCategory.CategoryName == model.CategoryName).ToList();
                    foreach (var time in timeReservations)
                    {
                        if( reservation.Resource.Name == time.Resource.Name && time.EventStart<=DateTime.Today)
                        {
                            DateTime timeRestricition = DateTime.Today;
                            if(time.EventEnd < timeRestricition)
                            {
                                timeRestricition = time.EventEnd;
                            }
                            if (time.EventStart == timeRestricition)
                            {
                                totalTime += Convert.ToDouble((timeRestricition - time.EventStart).TotalMinutes);
                            }
                            else
                            {
                                totalTime += Convert.ToDouble(((timeRestricition - time.EventStart).TotalDays)*480);
                            }
                        }
                      

                    }

                    ResourceStatistic.Usage = Convert.ToDouble((totalTime / (AdminDashboard.ResultSpan*480)) * 100);
                    AdminDashboard.ResourceStatistics.Add(ResourceStatistic);
                }
            }

            var Ordered=AdminDashboard.ResourceStatistics.OrderByDescending(x => x.Usage).Take(AdminDashboard.NumberOfResults).ToList();
            AdminDashboard.ResourceStatistics = Ordered;
            return AdminDashboard;
        }
    }
}