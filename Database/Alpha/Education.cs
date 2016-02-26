using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "The education must have a name")]
        public string Name { get; set; }            // School (course, certificate) name
        [Required(ErrorMessage ="The education must belong to a type")]
        public EducationType Type { get; set; }     // Education type

        public virtual ICollection<EmployeeEducation> EmployeeEducation { get; set; }       // list of employees who achieved this
    }
}
