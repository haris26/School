using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class CharacteristicNameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResourceCategory { get; set; }
        public string ResourceCategoryName { get; set; }
    }
}