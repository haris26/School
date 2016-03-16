using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Database;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class EducationsController : BaseController<Education>
    {
        public EducationsController(Repository<Education> depo) : base(depo)
        { }

        public List<EducationModel> Get(int id)
        {
            return Repository.Get().Where(x => x.Type == (EducationType)id).ToList()
                             .Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Post(Education education)
        {
            try
            {
                Repository.Insert(education);
                return Ok(Factory.Create(education));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Put(int id, Education education)
        {
            try
            {
                Education oldEducation = Repository.Get(id);
                if (oldEducation == null)
                    return NotFound();
                else
                    Repository.Update(education, id);
                return Ok(Factory.Create(education));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Education education = Repository.Get(id);
                if (education == null)
                    return NotFound();
                else
                    Repository.Delete(id);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
