using Database;
using System.Web.Http;
using WebAPI.Filters;
using WebAPI.Helpers;


namespace WebAPI.Controllers
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
