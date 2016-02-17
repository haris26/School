// SKILLS LIBRARY
namespace Database
{
//  Skill list for one person / tool
    public class EmployeeSkill
    {
        public int Id { get; set; }                     // Identity[1]
        public Level Level { get; set; }                  // Level [1-5]
        public int Experience { get; set; }             // Experience [years/months]
        
        public virtual Tool Tool { get; set; }          // Navigation to Tool
        public virtual Person Employee { get; set; }    // Navigation to Person
    }
}
