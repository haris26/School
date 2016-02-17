// SKILLS LIBRARY
namespace Database
{
//  List of skills in use on the particular project
    public class ProjectSkill
    {
        public int Id { get; set; }                 // Identity[1]
        public int Level { get; set; }              // Desired (or actual) Level [1-5]

        public virtual Tool Tool { get; set; }      // Navigation to Tool
        public virtual Team Team { get; set; }      // Navigation to Team
    }
}
