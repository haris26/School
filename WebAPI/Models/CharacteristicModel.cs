using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class CharacteristicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public int Resource { get; set; }
        public string ResourceName { get; set; }
    }
}