using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class EmployeeNotificationModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool AssessedBySupervisor { get; set; }
    }
}