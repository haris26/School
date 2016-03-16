using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RolesController : BaseController<Role>
    {
        public RolesController(Repository<Role> depo) : base(depo)
        { }

        public IList<RoleModel> Get()
        {
            return Repository.Get().ToList().Select(x => Factory.Create(x)).ToList();
        }
    }
}
