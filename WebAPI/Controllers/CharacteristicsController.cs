﻿using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[TokenAuthorize]
    public class CharacteristicsController : BaseController<Characteristic>
    {
        
        public CharacteristicsController(Repository<Characteristic> depo) : base(depo)
        { }

        public IList<CharacteristicModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }

        public IHttpActionResult Get(string type)
        {
            try
            {
                if (type != null)

                    return Ok(CharacteristicValues.Create(type, Repository.BaseContext()));
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        public IHttpActionResult Post(CharacteristicModel model)
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

        public IHttpActionResult Put(int id, CharacteristicModel model)
        {
            try
            {
                Characteristic characteristic = Repository.Get(id);
                if (characteristic == null)
                    return NotFound();
                else
                { 
                    Repository.Update(Parser.Create(model, Repository.BaseContext()), characteristic.Id);
                    return Ok(model);
                }
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
                Characteristic characteristic = Repository.Get(id);
                if (characteristic == null)
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

