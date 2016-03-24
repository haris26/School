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
        //public IList<ListModel> Roles { get; set; }
        //public IList<ListModel> Skills { get; set; }
        //public IList<ListModel> Reservations { get; set; }
        public IList<ListModel> Days { get; set; }
    }
}

