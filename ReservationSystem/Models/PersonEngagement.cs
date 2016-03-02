<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Database;
=======
﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
>>>>>>> haris

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
<<<<<<< HEAD

=======
>>>>>>> haris
    }
}