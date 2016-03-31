using Database;
using System.Web.Http;
using WebApi.Filters;
using WebApi.Helpers;
using WebAPI.Filters;

namespace WebApi.Controllers
{
    [SchoolAuthorize(true)]
    public class AdminDashboardController:ApiController
    {
        
   public IHttpActionResult Get(int id=0)
        {
            if (id == 2)
            {
                return Ok(AdminOfficeDashboard.Create());
            }
            else 
            
                return Ok(AdminDashboard.Create());
            
        }
    }
}
