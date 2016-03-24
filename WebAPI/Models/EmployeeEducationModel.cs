using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeEducationModel
    {
        public int Id { get; set; }
        public int Employee { get; set; }
        public int Education { get; set; }
        public string EducationName { get; set; }
        public string Reference { get; set; }
        public EducationType Type { get; set; }
    }
}