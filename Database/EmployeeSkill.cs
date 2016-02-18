// SKILLS LIBRARY
namespace Database
{
//  Skill list for one person / tool
    public class EmployeeSkill
    {
        public int Id { get; set; }                     // Identity[1]
<<<<<<< HEAD
        public Level Level { get; set; }                // Level [1-5]
=======
        public Level Level { get; set; }                  // Level [1-5]
>>>>>>> 2ac51a95ae3e842e7895c5d6981a52e83011c5ab
        public int Experience { get; set; }             // Experience [years/months]
        
        public virtual Tool Tool { get; set; }          // Navigation to Tool
        public virtual Person Employee { get; set; }    // Navigation to Person
    }
}
