using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmploymentType Category { get; set; }
        public EmploymentStatus Status { get; set; }
        public string Email { get; set; }
     


    }
}