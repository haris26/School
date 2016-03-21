using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class ResourceCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public int TimeDuration { get; set; }
    }
}