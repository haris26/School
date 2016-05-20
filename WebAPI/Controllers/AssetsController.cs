using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Controllers;
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
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x=>x.Status==AssetStatus.Assigned).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> freeassets =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x => x.Status==AssetStatus.Free && x.AssetCategory.assetType==AssetType.Device).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> freeofficeassets =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x => x.User == null && x.Status == AssetStatus.Free && x.AssetCategory.assetType==AssetType.Office).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> officeassets =
               query.Skip(PageSize * page).Take(PageSize).ToList().Where(x =>x.Status == AssetStatus.Assigned && x.AssetCategory.assetType == AssetType.Office).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> deviceassets =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x =>x.Status == AssetStatus.Assigned && x.AssetCategory.assetType == AssetType.Device).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> allofficeassets =
             query.Skip(PageSize * page).Take(PageSize).ToList().Where(x =>x.AssetCategory.assetType == AssetType.Office).Select(x => Factory.Create(x)).ToList();

            IList<AssetsModel> alldeviceassets =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x =>x.AssetCategory.assetType == AssetType.Device).Select(x => Factory.Create(x)).ToList();


            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                allAssets = assets,
                freeAssets=freeassets,
                officeFreeAssets=freeofficeassets,
                officeAssets=officeassets,
                deviceAssets=deviceassets,
                allOfficeAssets=allofficeassets,
                allDeviceAssets=alldeviceassets
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
                return Ok(Repository.BaseContext().Assets.ToList().Select(x => x.Id).Last());
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
                Asset a = Repository.Get(id);
                if (a == null)
                {
                    return NotFound();
                }
                else
                {
                    var entity = Parser.Create(model, Repository.BaseContext());
                    Repository.Update(entity, model.Id);
                    return Ok(model);
                }
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