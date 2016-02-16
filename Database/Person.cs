﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Database
{
    public class Address
    {
        public Address(string _zip, string _town, string _road)
        {
            ZipCode = _zip;
            Town = _town;
            Road = _road;
        }
        public string ZipCode { get; set; }
        public string Town { get; set; }
        public string Road { get; set; }
    }

    public class Person
    {
        public Person()
        {
            Roles = new List<Engagement>();
            EmployeeSkills = new Collection<EmployeeSkill>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Employment Category { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Status Status { get; set; }

        public virtual IList<Engagement> Roles { get; set; }
<<<<<<< HEAD
        public virtual IList<Team> Teams { get; set; }
=======
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
>>>>>>> d0bb89dd3fc3a3487c01103da40786699bf28379
    }
}
