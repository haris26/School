using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    class HistoryUnit : Repository<History>
    {
        public HistoryUnit(SchoolContext context) : base(context)
        {

        }

        public override void Insert(History history)
        {
            context.Histories.Add(history);
            
            context.SaveChanges();
        }
    }
}
