﻿using Database;
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
    public class AllRequestsController : BaseController<Request>
    {
        public AllRequestsController(Repository<Request> depo) : base(depo) { }




        public Object GetAll(int page = 0)
        {
            int PageSize = 15;
            var query =
               Repository.Get()
                   .OrderBy(x => x.Status)
                   .ThenBy(x => x.RequestDate)
                 .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<RequestModel> completeddevicerequests =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x =>x.AssetCategory.assetType==AssetType.Device && x.Status==RequestStatus.Completed).Select(x => Factory.Create(x)).ToList();

            IList<RequestModel> completedofficerequests =
              query.Skip(PageSize * page).Take(PageSize).ToList().Where(x => x.AssetCategory.assetType == AssetType.Office && x.Status==RequestStatus.Completed).Select(x => Factory.Create(x)).ToList();

            int count = 0;
            for (int i = 0; i < completeddevicerequests.Count(); i++)
            {
                if (completeddevicerequests[i].Status == (RequestStatus.Completed).ToString())
                {
                    count++;
                }
            }

            for (int i = 0; i < completedofficerequests.Count(); i++)
            {
                if (completedofficerequests[i].Status == (RequestStatus.Completed).ToString())
                {
                    count++;
                }
            }



            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                completedDeviceRequests = completeddevicerequests,
                completedOfficeRequests = completedofficerequests,
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
                if (model.AssetType == "2" && model.RequestType == "2")
                {
                    Mail.SendMail("harismistral@gmail.com", "Request Notification", "Dear Haris, you have one service request!");
                }
                else if ((model.AssetType == "2" || model.AssetType == "Office") && (model.RequestType == "1" || model.RequestType == "New"))
                {
                    Mail.SendMail("harismistral@gmail.com", "Request Notification", "Dear Haris, you have one new equipment request!");
                }
                else if (model.AssetType == "1" && model.RequestType == "2")
                {
                    Mail.SendMail("edibmistral@gmail.com", "Request Notification", "Dear Edib, you have one service request!");
                }
                else if ((model.AssetType == "1" || model.AssetType == "Device") && (model.RequestType == "1" || model.RequestType == "New"))
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
                    model.Status = "New";
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
                else if (model.Status == "6")
                {
                    model.Status = "In Proccess";
                }
                else if (model.Status == "7")
                {
                    model.Status = "Waiting For User Feedback";
                }
                else if (model.Status == "8")
                {
                    model.Status = "Waiting For Third Party";
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