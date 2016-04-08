using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    public class ListModel
    {
        public string Category { get; set; }
        public int Count { get; set; }
    }

    public class EmptyModel
    {
        public string Category { get; set; }
        public int EmptyDays { get; set; }
    }

    public class CountModel
    {
<<<<<<< HEAD:WebAPI/DashboardModel.cs
        public string Category { get; set; }
        public int Count { get; set; }
        public int EmptyDays { get; set; }
    }
=======
        public int Count { get; set; }
        public int EmptyDays { get; set; }
        public string Category { get; set; }

    }
    public class EmptyDayModel
    {
        public int EmptyDays { get; set; }
>>>>>>> c1e56a37f6085f2a384425186de696ccddef86c6:WebAPI/Models/DashboardModel.cs

    public class DeadlineModel
    {
        public int Deadline { get; set; }
        public string ZeroDeadline { get; set; }
    }


    public class DashboardModel
    {
        public DashboardModel()
        {
            //Roles = new List<ListModel>();
            //Skills = new List<ListModel>();
            //Reservations = new List<ListModel>();
            Days = new List<ListModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountEmpty { get; set; }
        //public IList<ListModel> Roles { get; set; }
        //public IList<ListModel> Skills { get; set; }
        //public IList<ListModel> Reservations { get; set; }
        public IList<ListModel> Days { get; set; }
        
    }
}

