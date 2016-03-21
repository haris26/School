using System;
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
    public class AssetCharsController : BaseController<AssetChar>
    {
        public AssetCharsController(Repository<AssetChar> depo) : base(depo) { }
        public Object GetAll(int page = 0)
            {
                int PageSize = 5;
                var query =
                   Repository.Get()
                       .OrderBy(x => x.Name)
                       .ThenBy(x => x.Value)
                       .ToList();

                int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

                IList<AssetCharsModel> characteristics =
                    query.Skip(PageSize * page).Take(PageSize).ToList().Select(x => Factory.Create(x)).ToList();

                return new
                {
                    pageSize = PageSize,
                    currentPage = page,
                    pageCount = TotalPages,
                    allCharacteristics = characteristics
                };
            }


            public IHttpActionResult Get(int id)
            {
                try
                {
                    AssetChar assetChar = Repository.Get(id);
                    if (assetChar == null)
                    {
                        return NotFound();

                    }
                    else

                        return Ok(Factory.Create(assetChar));

                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }



            public IHttpActionResult Post(AssetCharsModel model)
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



            public IHttpActionResult Put(int id, AssetCharsModel model)
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