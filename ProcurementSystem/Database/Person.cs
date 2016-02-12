using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public enum emp_type { ITofficer = 1, OfficeManager = 2, Employer = 3 };
  

    public class Person
    {
        public emp_type loyee { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }


    }
}
