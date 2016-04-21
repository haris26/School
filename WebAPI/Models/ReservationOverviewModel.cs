using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class CharacteristicsListModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class EventsListModel
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Person { get; set; }
        public string PersonName { get; set; }
        public string Time { get; set; }
    }

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

    public class ReservationOverviewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public IList<CharacteristicsListModel> Characteristics { get; set; }
        //public IList<EventsListModel> Events { get; set; }
        public IList<DeviceRowModel> table { get; set; }
        public ReservationOverviewModel()
        {
            Characteristics = new List<CharacteristicsListModel>();
            //Events = new List<EventsListModel>();
            table = new List<DeviceRowModel>();
        }

    }
}