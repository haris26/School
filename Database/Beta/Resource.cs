// RESERVATION SYSTEM
using Database.Beta;

namespace Database
{
//  Resources
    public class Resource
    {
        public int Id { get; set; }                                         // Identity[1]
        [ResourceControl]
        public string Name { get; set; }                                    // Name
        [StatusControl]
        public ReservationStatus Status { get; set; }                       // Reservation status of resource
        public virtual ResourceCategory  ResourceCategory { get; set;}      // Navigation to the resource category
    }
}
