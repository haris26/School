using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    public class ListTeamsModel
    {

        public ListTeamsModel()
        {
            //including this entire DateTime code in order to initiate a default vaulue for MissedDays variable to show the days not logged on a team level
            int dd = DateTime.Now.Month; //(year: 2016, month: 3, day: 1);
            int dty = DateTime.Now.Year;
            int bd = DateTime.DaysInMonth(dty, dd);
            var weekends = new DayOfWeek[] { DayOfWeek.Saturday, DayOfWeek.Sunday };
            IEnumerable<int> businessDaysInMonth = Enumerable.Range(1, bd)
                                                   .Where(d => !weekends.Contains(new DateTime(dty, dd, d).DayOfWeek));
            
            MissedDays = businessDaysInMonth.Count();   //giving a variable a default value of number of business days in a given month
            Details = new List<ListModel>();
            Days = new List<ListModel>();
            Members = new List<CountModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MissedDays { get; set; }
        public IList<ListModel> Days { get; set; }        
        public IList<ListModel> Details { get; set; }
        public IList<CountModel> Members { get; set; }

    }
}