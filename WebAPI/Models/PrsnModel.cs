using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{

    public class PrsnModel
    {

        public PrsnModel()
        {
            Days = new List<CountModel>();
            Details = new List<ListModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IList<CountModel> Days { get; set; }
        public IList<ListModel> Details { get; set; }
    }
}