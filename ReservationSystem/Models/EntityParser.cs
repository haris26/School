using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Database;

namespace ReservationSystem.Models
{
    public class EntityParser
    {
        public Event Create(EventModel model, SchoolContext context)
        {
            return new Event()
            {
                Id = model.Id,
                EventTitle = model.EventTitle,
                EventStart = model.StartDate,
                EventEnd = model.EndDate,
                User = context.People.Find(model.Person),
                Resource = context.Resources.Find(model.Resource)
            };
        }
        //Irhad on EntityParser
        //public CharacteristicNameModel Create(CharacteristicName characteristicName)
        //{
        //    return new CharacteristicNameModel()
        //    {
        //        Id = characteristicName.Id,
        //        Name = characteristicName.Name,
        //        ResourceCategory = characteristicName.ResourceCategory.Id,
        //        ResourceCategoryName = characteristicName.ResourceCategory.CategoryName
        //    };
        //}

    }
}