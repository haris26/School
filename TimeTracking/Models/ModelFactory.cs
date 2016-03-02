using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using TimeTracking.Models;


namespace TimeTracking.Models
{
    public class ModelFactory
    {

        private SchoolContext context;

        public ModelFactory(SchoolContext ctx)
        {
            context = ctx;
        }


        public TeamModel Create(Team team)
        {
            TeamModel model = new TeamModel()
            {
                Id = team.Id,
                Name = team.Name,
                Description = team.Description,
                Type = team.Type.ToString()
            };
            foreach (var person in team.Roles)
            {
                model.Members.Add(person.Person.FirstName + " " + person.Person.LastName);
            }
            return model;
        }

        public EngagementModel Create(Engagement engagement)
        {
            return new EngagementModel()
            {
                Id = engagement.Id,
                StartDate = engagement.StartDate,
                EndDate = engagement.EndDate,
                Time = engagement.Time,
                Person = engagement.Person.Id,
                PersonName = engagement.Person.FirstName + " " + engagement.Person.LastName,
                Team = engagement.Team.Id,
                TeamName = engagement.Team.Name,
                Role = engagement.Role.Id,
                RoleName = engagement.Role.Name
            };
        }


        public DayModel Create(Day day)
        {
            return new DayModel()
            {
                Id = day.Id,
                Person = day.Person.Id,
                PersonName = day.Person.FirstName + " " + day.Person.LastName,
                Date = day.Date,
                WorkTime = day.WorkTime,
                PtoTime = day.PtoTime,
                EntryStatus = day.EntryStatus
            };


        }
        public DetailModel Create(Detail detail)
        {
            return new DetailModel()
            {
                Id = detail.Id,
                Day = detail.Day.Id,
                Date=detail.Day.Date,
                PersonName = detail.Day.Person.FirstName,
                WorkTime = detail.WorkTime,
                BillTime = detail.BillTime,
                Description = detail.Description,
                Team = detail.Team.Id,
                TeamName = detail.Team.Name
            };
        }

        public PersonModel Create(Person person)
        {
            return new PersonModel()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Category = person.Category,
                Status = person.Status
            };
        }
}

}