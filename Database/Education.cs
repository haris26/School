using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Education
    {
        public Education()
        {
            EmployeeEducation = new Collection<EmployeeEducation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public EducationType Type { get; set; }
        public string Reference { get; set; }

        public virtual ICollection<EmployeeEducation> EmployeeEducation { get; set; }
    }
}
