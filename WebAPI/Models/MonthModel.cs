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
            Empty = new List<EmptyModel>();
         }
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CountModel> Days { get; set; }
        public IList<ListModel> Details { get; set; }
        public IList<EmptyModel> Empty { get; set; }

        }
}