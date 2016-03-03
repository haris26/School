using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ReservationSystem.Models
{
    public class ResourceCharactersticModel
    {
        public ResourceCharactersticModel()
        {
            Characteristics = new List<CharacteristicModel>();
        }
        public Resource Resource { get; set; }
        public IList<CharacteristicModel> Characteristics { get; set; }
        public Characteristic Charac { get; set; }
    }
}