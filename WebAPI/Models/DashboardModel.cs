using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ListModel
    {
        public string Category { get; set; }
        public int Count { get; set;}
        public string Message { get; set; }
    }

    public class DashboardModel
    {
        public DashboardModel()
        {
           
            Assets = new List<ListModel>();
            Requests = new List<ListModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        
        public IList<ListModel> Assets { get; set; }
        public IList<ListModel> Requests { get; set; }
    }
}