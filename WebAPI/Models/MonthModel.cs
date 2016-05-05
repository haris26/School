using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MonthModel
    {
        public MonthModel()
        {
            Details = new List<ListModel>();
            Days = new List<CountModel>();
            
         }
        
        public MonthModel(int month)
        {

            Details = new List<ListModel>();
            Days = new List<CountModel>();            

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public IList<CountModel> Days { get; set; }
       // public IList<EmptyDayModel> EmptyDays { get; set; }
        public IList<ListModel> Details { get; set; }
        public int DeadLineIn { get; set; }
        public int TotalHours { get; set; }
        public int EmptyDays { get; set; }

        }
}