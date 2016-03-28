//using Database;
//using System.Web.Http;
//using WebApi.Filters;
//using WebApi.Helpers;
//using WebAPI.Filters;

//namespace WebApi.Controllers
//{
//    [TokenAuthorize]
//    public class AdminITController: BaseController<History>
//    {
//        SchoolIdentity ident = new SchoolIdentity();

//        public AdminITController(Repository<History> depo) : base(depo)
//        { }

//        public IHttpActionResult Get(int id = 0)
//        {
//            History history;
           
//            if (id == 0)
//            {
//               history = ident.currentHistory;
//            }
//            else
//                history = Repository.Get(id);

//            return Ok(Dashboard.Create(person));
//        }
//    }
//}
