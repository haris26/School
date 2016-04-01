using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ResourceStats
    {
        public ResourceStats()
        {
            Characteristics = new List<CharacteristicsListModel>();
        }
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public IList<CharacteristicsListModel> Characteristics { get; set; }
        public int Usage { get; set; }
    }

    public class AdminDashboardModel
    {    
         public int ResultSpan { get; set; }
         public int NumberOfResults { get; set; }
         public IList<ResourceStats> ResourceStatistics { get; set; }
    }
}