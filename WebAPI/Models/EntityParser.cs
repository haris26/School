﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EntityParser
    {
      

        //public EntityParser(SchoolContext ctx)
        //{
        //    context = ctx;
        //}

        //public Engagement Create(EngagementModel model)
        //{
        //    return new Engagement()
        //    {
        //        Id = model.Id,
        //        StartDate = model.StartDate,
        //        EndDate = model.EndDate,
        //        Time = model.Time,
        //        Person = context.People.Find(model.Person),
        //        Team = context.Teams.Find(model.Team),
        //        Role = context.Roles.Find(model.Role)
        //    };
        //}

        public Day Create(DayModel model, SchoolContext context)
        {
            return new Day()
            {
                Id = model.Id,
                Person = context.People.Find(model.Person),
                Date = model.Date,
                WorkTime = model.WorkTime,
                PtoTime = model.PtoTime,
                EntryStatus = model.EntryStatus
            };
        }


        public Person Create(PersonModel model, SchoolContext context )
        {
            return new Person()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Category = model.Category,
                Status = model.Status,
                Email=model.Email
            };
        }

        public Detail Create(DetailModel model, SchoolContext context)
        {
            return new Detail()
            {
                Id = model.Id,
                Day = context.Days.Find(model.Day),
                WorkTime = model.WorkTime,
                //BillTime = model.BillTime,
                Description = model.Description,
                Team = context.Teams.Find(model.Team)

            };
        }
    }
}