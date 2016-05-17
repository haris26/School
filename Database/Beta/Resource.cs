// RESERVATION SYSTEM

using System.Collections.Generic;
using Database.Beta;

namespace Database
{
//  Resources
    public class Resource
    {
        public int Id { get; set; }                                         // Identity[1]
        [ResourceControl]
        public string Name { get; set; }                                    // Name
        public virtual ResourceCategory  ResourceCategory { get; set;}      // Navigation to the resource category
        public virtual ICollection<Characteristic> Characteristics { get; set; }
        public virtual ICollection<Event> Events { get; set; }
    }
}
