﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebApi.Controllers;

namespace WebAPI.Controllers
{
    public class AssetCategoriesController : BaseController<AssetCategory>
    {
        public AssetCategoriesController(Repository<AssetCategory> depo) : base(depo)
        { }

        public Object GetAll(int page = 0)
        {
            int PageSize = 5;
            var query =
               Repository.Get()
                   .OrderBy(x => x.CategoryName)
                   .ThenBy(x => x.AssetCharacteristicNames)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<AssetCategoriesModel> people =
                query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allPeople = people
            };
        }


        public IHttpActionResult Get(int id)
        {
            try
            {
                AssetCategory assetCat = Repository.Get(id);
                if (assetCat == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(assetCat));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        public IHttpActionResult Post(AssetCategoriesModel model)
        {
            try
            {
                Repository.Insert(Parser.Create(model, Repository.BaseContext()));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        public IHttpActionResult Put(int id, AssetCategoriesModel model)
        {
            try
            {
                Repository.Update(Parser.Create(model, Repository.BaseContext()), model.Id);
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