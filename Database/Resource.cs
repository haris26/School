
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Database
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ResourceCategory ResourceCategory { get; set; }
        public ReservationStatus Status { get; set; }
        public virtual ICollection<CategoryDetail> Characteristics { get; set; }

        public Resource()
        {
            Characteristics = new Collection<CategoryDetail>();
        }
    }
}
