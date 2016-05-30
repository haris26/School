using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;
using WebAPI.Controllers;

namespace WebAPI.Controllers
{
    public class AssetCategoriesController : BaseController<AssetCategory>
    {
        SchoolContext context = new SchoolContext();

        public class CharValueModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Value { get; set; }
            public int AssetId { get; set; }
        }

        public AssetCategoriesController(Repository<AssetCategory> depo) : base(depo)
        { }

        public Object GetAll(int page = 0)
        {
            int PageSize = 15;
            var query =
               Repository.Get()
                   .OrderBy(x => x.CategoryName)
                   .ToList();

            int TotalPages = (int)Math.Ceiling((double)query.Count() / PageSize);

            IList<AssetCategoriesModel> officeCategories =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x => x.assetType == AssetType.Office).Select(x => Factory.Create(x)).ToList();

            IList<AssetCategoriesModel> deviceCategories =
                query.Skip(PageSize * page).Take(PageSize).ToList().Where(x => x.assetType == AssetType.Device).Select(x => Factory.Create(x)).ToList();


            IList<AssetCategoriesModel> allCategories =
                          query.Skip(PageSize * page).Take(PageSize).Select(x => Factory.Create(x)).ToList();



            return new
            {
                pageSize = PageSize,
                currentPage = page,
                pageCount = TotalPages,
                deviceCategories = deviceCategories,
                officeCategories = officeCategories,
                allCategories = allCategories

            };
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                Asset asset = context.Assets.Find(id);
                AssetCategory assetCat = asset.AssetCategory;
                if (assetCat == null)
                {
                    return NotFound();

                }
                else
                {
                    IList<CharValueModel> listchars = new List<CharValueModel>();
                    foreach (var chName in assetCat.AssetCharacteristicNames)
                    {
                        var ch = context.AssetCharacteristics.Where(x => x.Asset.Id == asset.Id && x.Name == chName.Name).FirstOrDefault();
                        listchars.Add(new CharValueModel()
                        {
                            Id = (ch == null) ? 0 : chName.Id,
                            Name = chName.Name,
                            Value = (ch == null) ? "" : ch.Value,
                            AssetId = id
                        });
                    }

                    return Ok(listchars);
                }



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
                AssetCategory assetCat = Repository.Get(id);
                if (assetCat == null)
                    return NotFound();
                else
                {
                    Repository.Delete(id);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}