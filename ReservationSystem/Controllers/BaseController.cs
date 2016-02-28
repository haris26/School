
﻿using Database;
using System.Web.Mvc;
using ReservationSystem.Models;

namespace ReservationSystem.Controllers
{
    public class BaseController : Controller
    {
        private SchoolContext ctx;
        private ModelFactory fact;
        private EntityParser pars;

        public BaseController()
        {
            ctx = new SchoolContext();
        }

        protected SchoolContext Context
        {
            get { return ctx; }
        }
        //Singleton
        protected ModelFactory Factory
        {
            get
            {
                if (fact == null) fact = new ModelFactory(ctx);
                return fact;
            }
        }
        //Singleton
        protected EntityParser Parser
        {
            get
            {
                if (pars == null) pars = new EntityParser(ctx);
                return pars;
            }
        }

    }
}

