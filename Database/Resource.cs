// RESERVATION SYSTEM
namespace Database
{
//  Resources
    public class Resource
    {
        public int Id { get; set; }                                         // Identity[1]
        public string Name { get; set; }                                    // Name
        public ReservationStatus Status { get; set; }                       // Reservation status of resource
        public virtual ResourceCategory  ResourceCategory { get; set;}      // Navigation to the resource category
    }
}
