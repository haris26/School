using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Controllers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class AssetsController : BaseController<Asset>
    {
        public AssetsController(Repository<Asset> depo) : base(depo)
        { }

        public Object GetAll(int page = 0)
        {
            int PageSize = 15;
            var query =
               Repository.Get()
                   .OrderBy(x => x.Status)
                   .ThenBy(x => x.Model)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<AssetsModel> assets =
                query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allAssets = assets
            };
        }



        public IHttpActionResult Get(int id)
        {
            try
            {
                Asset asset = Repository.Get(id);
                if (asset == null)
                {
                    return NotFound();

                }
                else

                    return Ok(Factory.Create(asset));

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        public IHttpActionResult Post(AssetsModel model)
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



        public IHttpActionResult Put(int id, AssetsModel model)
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