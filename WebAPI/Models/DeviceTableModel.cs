using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class DeviceCellModel
    {
        public string EventTitle { get; set; }
        public string PersonName { get; set; }
        public bool IsReserved { get; set; }
        public bool IsPast { get; set; }
    }

    public class DeviceRowModel
    {
        public string Day { get; set; }
        public string Date { get; set; }

        public IList<DeviceCellModel> Hours { get; set; }

        public DeviceRowModel()
        {
            Hours = new List<DeviceCellModel>();
        }
    }
    public class DeviceTableModel
    {
       
        public IList<DeviceRowModel> Days {get;set;}

        public DeviceTableModel(DateTime date) {

           
            Days = new List<DeviceRowModel>();
            DateTime startDate = new DateTime();

            if (date.DayOfWeek.ToString() == "Monday") { startDate = date; }
            if (date.DayOfWeek.ToString() == "Tuesday") { startDate = date.AddDays(-1); }
            if (date.DayOfWeek.ToString() == "Wednesday") { startDate = date.AddDays(-2); }
            if (date.DayOfWeek.ToString() == "Thursday") { startDate = date.AddDays(-3); }
            if (date.DayOfWeek.ToString() == "Friday") { startDate = date.AddDays(-4); }

           

            for (int i = 0; i < 5; i++)
            {
                var hours = new List<DeviceCellModel>();
                var day = new DeviceRowModel
                {
                    Date = startDate.AddDays(i).ToShortDateString(),
                    Day = startDate.AddDays(i).DayOfWeek.ToString(),

                };

                for (int j = 0; j < 8; j++)
                {
                    
                    hours.Add(new DeviceCellModel
                    {
                        EventTitle = "",
                        PersonName = "",
                        IsPast = false,
                        IsReserved = false

                    });
                }

                day.Hours = hours;
                Days.Add(day);
            }
            
           

        }

        public void Add(int i, int j , DeviceCellModel newEvent)
        {
            Days[i].Hours[j] = newEvent;
        }
    }
}