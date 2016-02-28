//using Database;
//using ReservationSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace ReservationSystem.Controllers
//{
//    public class BaseController : Controller
//    {
//        private SchoolContext ctx;
//        private ModelFactory fact;
//        private EntityParser pars;
        
//        public BaseController()
//        {
//            ctx = new SchoolContext();
//        }
//        protected SchoolContext Context
//        {
//            get { return ctx; }
//        }
//        protected ModelFactory Factory
//        {
//            get
//            {
//                if (fact == null)
//                {
//                    fact = new ModelFactory(ctx);
//                }
//                return fact; 
//            }
//        }
//        protected EntityParser Parser
//        {
//            get
//            {
//                if (pars == null)
//                {
//                    pars = new EntityParser(ctx);
//                }
//                return pars;
//            }
//        }
//    }
//}