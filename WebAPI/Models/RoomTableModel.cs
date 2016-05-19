using Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class RoomCellModel
    {
        public string EventTitle { get; set; }
        public string PersonName { get; set; }
        public string EventStart { get; set; }
        public string EventEnd { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsReserved { get; set; }
        public bool IsPast { get; set; }
    }

    public class RoomRowModel
    {
        public int Id { get; set; }
        public string RoomName { get; set; }

        public IList<CharacteristicsListModel> Characteristics { get; set; }
        public IList<RoomCellModel> TimeSlots { get; set; }

        public RoomRowModel()
        {
            TimeSlots = new List<RoomCellModel>();
            Characteristics = new List<CharacteristicsListModel>();
        }
    }

    public class RoomTableModel
    {

        public RoomRowModel Room { get; set; }

        public RoomTableModel(DateTime date, Resource room)
        {
            SchoolContext context = new SchoolContext();
            TimeSpan ts = new TimeSpan(9, 0, 0);
            date = date.Date + ts;
            Room = new RoomRowModel
            {
                Id = room.Id,
                RoomName = room.Name
            };
            foreach (var ch in room.Characteristics)
            {
            Room.Characteristics.Add(new CharacteristicsListModel
                {
                    Id = ch.Id,
                    Name = ch.Name,
                    Value = ch.Value
                });
            }

            for (int i = 0; i < 32; i++)
            {
                Room.TimeSlots.Add(new RoomCellModel
                {
                    EventTitle = "",
                    PersonName = "",
                    EventStart = Convert.ToString(date.AddMinutes(i * 15)),
                    EventEnd = Convert.ToString(date.AddMinutes((i * 15) + 15)),
                    StartTime = date.AddMinutes(i * 15).ToShortTimeString(),
                    EndTime = date.AddMinutes((i * 15)+15).ToShortTimeString(),
                    IsReserved = false,
                    IsPast = false
                });
            }
        }
    }
}