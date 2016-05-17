using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class ResourceModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResourceCategory { get; set; }
        public string ResourceCategoryName { get; set; }
    }
}