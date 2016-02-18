// TIME TRACKING
namespace Database
{
//  work details for each day
    public class Detail
    {
        public int Id { get; set; }                         // Identity[1]
        public virtual Calendar Calendar { get; set; }      // Navigation to Calendar class (date and person)
        public double WorkTime { get; set; }                // Total work time
        public double BillTime { get; set; }                // Total bill time
        public bool Flag { get; set; }                      // fol de gol
        public string Description { get; set; }             // Description of the tasks performed
        public virtual Team Team { get; set; }              // Navigation to Team class (related Project)
    }
}
