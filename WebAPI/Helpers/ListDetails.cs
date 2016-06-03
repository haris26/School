using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Helpers
{
    public class ListDetails
    {
        public DayModel Create(Day day)
        {
            DayModel model = new DayModel()
            {
                Id = day.Id,
                Date = day.Date,
                Person = day.Person.Id,
                PersonName = day.Person.FullName,
                WorkTime = day.WorkTime

            };
            foreach (var detail in day.Details)
            {
                model.Details.Add(new DetailModel() { WorkTime = detail.WorkTime, Description = detail.Description, TeamName = detail.Team.Name  });
            }
            return model;
        }     
    }
}