using System.Collections.Generic;
using System.Collections.ObjectModel;

// SKILLS LIBRARY
namespace Database
{
//  Education table: school, courses, certificates...
    public class Education
    {
        public Education()
        {
            EmployeeEducation = new Collection<EmployeeEducation>();
        }

        public int Id { get; set; }                 // Identity[1]
        public string Name { get; set; }            // School (course, certificate) name
        public EducationType Type { get; set; }     // Education type

        public virtual ICollection<EmployeeEducation> EmployeeEducation { get; set; }       // list of employees who achieved this
    }
}
