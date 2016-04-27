using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class ServiceRequestsController : BaseController<Request>
    {
        public ServiceRequestsController(Repository<Request> depo) : base(depo) { }




        public Object GetAll(int page = 0)
        {
            int PageSize = 15;
            var query =
               Repository.Get()
                   .OrderBy(x => x.Status)
                   .ThenBy(x => x.RequestDate)
                   .Where(x => x.requestType == RequestType.Service)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);
            IList<RequestModel> requests =
               query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            int count = 0;
            for (int i = 0; i < requests.Count(); i++)
            {
                if (requests[i].Status == (RequestStatus.InProccess).ToString())
                {
                    count++;
                }
            }

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allRequests = requests,
                count
            };
        }


        public IHttpActionResult Get(int id)

        {
            try
            {
                Request request = Repository.Get(id);
                if (request == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(request));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(RequestModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                if (model.AssetType == "2" && model.requestType == "2")
                {
                    Mail.SendMail("harismistral@gmail.com", "Request Notification", "Dear Haris, you have one service request!");
                }
                else if ((model.AssetType == "2" || model.AssetType == "Office") && (model.requestType == "1" || model.requestType == "New"))
                {
                    Mail.SendMail("harismistral@gmail.com", "Request Notification", "Dear Haris, you have one new equipment request!");
                }
                else if (model.AssetType == "1" && model.requestType == "2")
                {
                    Mail.SendMail("edibmistral@gmail.com", "Request Notification", "Dear Edib, you have one service request!");
                }
                else if ((model.AssetType == "1" || model.AssetType == "Device") && (model.requestType == "1" || model.requestType == "New"))
                {
                    Mail.SendMail("edibmistral@gmail.com", "Request Notification", "Dear Edib, you have one new equpiment request.");
                }

                
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, RequestModel model)
        {
            try
            {
                Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
                if (model.Status == "2")
                {
                    Mail.SendMail("alen.bumbulovic@live.com", "Request approval", "There is a request that needs Your approval." + "<br/>" + " From: " + model.PersonName + "<br/>" + " Request Message: " + model.RequestMessage + "<br/>" + " Request description: " + model.RequestDescription + "<br/>" + " Quantity: " + model.Quantity);
                }

                if (model.Status == "1")
                {
                    model.Status = "InProccess";
                }
                else if (model.Status == "2")
                {
                    model.Status = "Waiting for approval";
                }
                else if (model.Status == "3")
                {
                    model.Status = "Approved";
                }
                else if (model.Status == "4")
                {
                    model.Status = "Completed";
                }
                else if (model.Status == "5")
                {
                    model.Status = "Cancelled";
                }
                Mail.SendMail(model.Email, "Request status", "Your request status is now: " + model.Status);

              
                return Ok(model);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}