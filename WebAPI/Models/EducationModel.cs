using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;

namespace WebAPI.Models
{
    public class EducationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EducationType Type { get; set; }
    }
}