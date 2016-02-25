using Database.Delta;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

// WORKFORCE ROSTER
namespace Database
{
    public class Address
    {
        public Address() {
            ZipCode = "n/a";
            Town = "n/a";
            Road = "n/a";
        }

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
            Roles = new Collection<Engagement>();
            Teams = new Collection<Team>();
            EmployeeSkills = new Collection<EmployeeSkill>();
        }

        public int Id { get; set; }
        [SymbolControl]
        public string FirstName { get; set; }
        [SymbolControl]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public EmploymentType Category { get; set; }
        public Gender Gender { get; set; }
        public string Image { get; set; }
        [Required]
        public string Phone { get; set; }
        public Address Address { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public EmploymentStatus Status { get; set; }

        public virtual ICollection<Engagement> Roles { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
