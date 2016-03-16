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
    public class BaseController<T> : ApiController where T : class
    {
        private Repository<T> depo;
        private ModelFactory fact;
        private EntityParser parser;

        public BaseController(Repository<T> _depo)
        {
            depo = _depo;
        }

        protected Repository<T> Repository
        {
            get { return depo; }
        }

        protected ModelFactory Factory
        {
            get
            {
                if (fact == null) fact = new ModelFactory();
                return fact;
            }
        }

        protected EntityParser Parser
        {
            get
            {
                if (parser == null) parser = new EntityParser();
                return parser;
            }
        }
    }
}