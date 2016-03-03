<<<<<<< HEAD
=======
using Database;
>>>>>>> 9234915cb657b0a168ec514926ed98677a1475a6
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class PersonEngagement
    {
        public PersonEngagement()
        {
            Engagements = new List<EngagementModel>();
        }
        public Person Person { get; set; }
        public IList<EngagementModel> Engagements { get; set; }
    }
}