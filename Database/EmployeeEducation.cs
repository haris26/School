// SKILLS LIBRARY
namespace Database
{
//  Collection of diplomas and certificates for employee
//  Collection of employees who achieved particular school, course or certificate
    public class EmployeeEducation
    {
        public int Id { get; set; }

        public virtual Person Employee { get; set; }
        public virtual Education Education { get; set; }
        public string Reference { get; set; }       // Reference (link)
    }
}
