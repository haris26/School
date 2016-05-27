using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    public class EmployeeNotificationsController : BaseController<EmployeeNotification>

    {
        SchoolIdentity ident = new SchoolIdentity();

        public EmployeeNotificationsController(Repository<EmployeeNotification> depo) : base(depo){ }

        public IHttpActionResult GetByEmployee(int id)
        {
            try
            {
              var Id = Repository.Get().Where(x=> x.Employee.Id==id).Select(x=>x.Id).FirstOrDefault();
                return Ok(Factory.Create(Repository.Get(Id)));
            }
           
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(EmployeeNotificationModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        public IHttpActionResult Put(int id, EmployeeNotificationModel model)
        {
            try
            {
                EmployeeNotification employeeNotification = Parser.Create(model, Repository.BaseContext());
                Repository.Update(employeeNotification, id);
                return Ok(Factory.Create(employeeNotification));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    }

