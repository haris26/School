using System;

// WORKFORCE ROSTER
namespace Database
{
//  Engagement on project
    public class Engagement
    {
        public int Id { get; set; }                         // Identity[1]
        public DateTime StartDate { get; set; }             // Start on project
        public DateTime? EndDate { get; set; }              // End of engagement [null if person is still active on that project]
        public int Time { get; set; }                       // Weekly hours of engagement
        public virtual Person Person { get; set; }          // Navigation to Person
        public virtual Role Role { get; set; }              // Navigation to Role - what role he has in the team
        public virtual Team Team { get; set; }              // Navigation to Project 
    }
}
