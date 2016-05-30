using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RequestUnit : Repository<Request>
    {
        public RequestUnit(SchoolContext context) : base(context)
        {

        }

        public override void Insert(Request request)
        {
            context.Requests.Add(request);
            context.SaveChanges();
        }
    }
}
