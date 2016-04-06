using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class MonthModel
    {
        
        public MonthModel(int month)
        {

            Details = new List<ListModel>();
            Days = new List<CountModel>();
           
            
            EmptyDays = new List<EmptyDayModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CountModel> Days { get; set; }
        public IList<EmptyDayModel> EmptyDays { get; set; }
        public IList<ListModel> Details { get; set; }
        public int DeadLineIn { get; set; }
        

    }
}